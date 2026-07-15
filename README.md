# MCP .NET Client-Server Architecture

An implementation of the Model Context Protocol (MCP) in C#, enabling seamless AI integration with external tools and services.

## Why This Project Matters

This project demonstrates:
- **AI Integration**: Connect Claude AI with custom business logic
- **Tool Discovery**: Automatic discovery of available tools
- **Security**: User secrets, authentication, and secure token handling

## Features

### Server
- ✅ Dynamic tool discovery with JSON Schema
- ✅ Country lookup by currency and vice versa
- ✅ GitHub API integration via User Secrets
- ✅ Prompts and Resources support

### Client
- ✅ MCP protocol implementation
- ✅ AI-powered tool calling
- ✅ GitHub Models integration
- ✅ Chat interface with tool execution
- ✅ Error handling and logging

## Quick Start

### Prerequisites
- .NET 8.0+
- Claude Desktop (for local testing)
- GitHub Personal Access Token (for GitHub tools)

# Run Locally
## Clone the repository
git clone https://github.com/amna-hashim/MCPShowCase.git
cd mcp-dotnet-showcase

## Run the server
cd src/McpServer
dotnet run

### Option 1: Local Development with Claude Desktop
1. **Configure Claude Desktop**
   Copy the [Claude Desktop configuration](examples/claude-desktop-config.json) to:
   - Windows: `%APPDATA%\Claude\claude_desktop_config.json`
2. Save the file. 
3. Exit and restart Claude Desktop to apply the new configuration.
4. Use the chat interface to interact with the server and execute tools.
  - Example queries to try available at (examples/sample-queries.md)
	
### Option 2: Use Custom Client
1. cd src/McpClient
   dotnet run
2. Use the chat interface to interact with the server and execute tools.
  - Example queries to try available at (examples/sample-queries.md)