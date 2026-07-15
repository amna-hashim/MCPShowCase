using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using ModelContextProtocol.Client;
using OpenAI;
using System.ClientModel;
using System.Text.Json;

try
{
    var transport = new StdioClientTransport(new()
    {
        Command = "dotnet",
        Arguments = ["C:\\learning_AI\\MCPShowCase\\McpServer\\bin\\Debug\\net10.0\\McpServer.dll"],
        Name = "McpServer"
    });


    var mcpClient = await McpClient.CreateAsync(transport);

    // List all available tools from the server
    Console.WriteLine("📦 Available Tools:");
    var tools = await mcpClient.ListToolsAsync();
    foreach (var tool in tools)
    {
        Console.WriteLine($"  🔧 {tool.Name}: {tool.Description}");
    }

    if (!tools.Any())
    {
        Console.WriteLine("⚠️ No tools found! Make sure your MCP server has tools defined.");
        return;
    }

    // dotnet user-secrets init
    //dotnet user-secrets set "GH_PAT" "github_pat_YOUR_TOKEN_HERE"

    // Load GitHub PAT from user secrets
    var config = new ConfigurationBuilder()
        .AddUserSecrets<Program>()
        .Build();

    var githubPAT = config["GH_PAT"]
        ?? throw new InvalidOperationException("GH_PAT not found in user secrets.");

    // GitHub Models endpoint — free, no Azure subscription needed
    var endpoint = new Uri("https://models.inference.ai.azure.com");
    var model = "gpt-4o-mini";

    // Create the client pointing to GitHub Models
    // Replace your client creation with this:
    var openAIClient = new OpenAIClient(
        new ApiKeyCredential(githubPAT),
        new OpenAIClientOptions
        {
            Endpoint = endpoint
        }
    );
    var chatClient = openAIClient.GetChatClient(model);

    var chatClientWithTools = new ChatClientBuilder(chatClient.AsIChatClient())
         .UseFunctionInvocation()
         .Build();

    Console.WriteLine("\n💬 AI Chat Mode (type 'exit' to quit)");
    Console.WriteLine("Available tools will be called automatically when needed.\n");

    var chatMessages = new List<ChatMessage>();

    while (true)
    {
        Console.Write("\nYou: ");
        var input = Console.ReadLine();
        if (input?.ToLower() == "exit") break;
        if (string.IsNullOrWhiteSpace(input)) continue;

        chatMessages.Add(new ChatMessage(ChatRole.User, input));
        var response = await chatClientWithTools.GetResponseAsync(chatMessages, new ChatOptions { Tools = [.. tools] });

        var assistantMessage = response.Messages;
        chatMessages.AddRange(assistantMessage);

        foreach (var message in chatMessages)
        {
            if (message.Contents.OfType<FunctionCallContent>().Any())
            {
                Console.WriteLine($"AI is thinking... (calling tools)");

                foreach (var functionCall in message.Contents.OfType<FunctionCallContent>())
                {
                    try
                    {
                        // Parse arguments
                        string json = JsonSerializer.Serialize(functionCall.Arguments ?? new Dictionary<string, object>());
                        var arguments = JsonSerializer.Deserialize<Dictionary<string, object>>(json)
                            ?? new Dictionary<string, object>();

                        Console.WriteLine($"Calling tool: {functionCall.Name} with args: {JsonSerializer.Serialize(arguments)}");

                        // Call the MCP tool
                        var result = await mcpClient.CallToolAsync(
                            functionCall.Name,
                            arguments
                        );

                        // Extract the result text
                        string resultText = "No result returned";
                        var firstContent = result.Content.FirstOrDefault();

                        if (firstContent != null)
                        {
                            var t = firstContent.GetType();
                            var typeName = t.Name;

                            if (typeName == "TextContent")
                            {
                                var p = t.GetProperty("Text");
                                resultText = p?.GetValue(firstContent)?.ToString() ?? resultText;
                            }
                            else if (typeName == "ImageContent")
                            {
                                var p = t.GetProperty("Data");
                                var data = p?.GetValue(firstContent) as byte[];
                                resultText = $"[Image: {data?.Length ?? 0} bytes]";
                            }
                            else if (typeName == "EmbeddedResourceContent")
                            {
                                var p = t.GetProperty("Uri");
                                resultText = $"[Resource: {p?.GetValue(firstContent)}]";
                            }
                            else
                            {
                                resultText = firstContent.ToString() ?? resultText;
                            }
                        }
                        Console.WriteLine($"Tool result: {resultText}");

                        // Add the tool result to the conversation
                        chatMessages.Add(new ChatMessage(
                            ChatRole.Tool,
                            resultText
                        ));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Tool call failed: {ex.Message}");
                        chatMessages.Add(new ChatMessage(
                            ChatRole.Tool,
                            $"Error: {ex.Message}"
                        ));
                    }
                }
            }
        }
    }


}
catch (Exception ex)
{

}

