using McpServer.Classes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

// Add MCP server services
builder.Services.AddMcpServer()
    .WithStdioServerTransport()  // For Claude Desktop communication
    .WithToolsFromAssembly();     // Auto-discover tools

builder.Logging.ClearProviders();

var app = builder.Build();

// Start the MCP server
await app.RunAsync();