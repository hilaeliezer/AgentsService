#AgentsService
This is a C# Web API with 3 GET endpoints.

## Requirements

- .NET 7.0 SDK or later
- Visual Studio Code or another C# IDE
- sqlServer

## Installation

1. Clone the repository to your local machine 'git clone https://github.com/hilaeliezer/AgentsService.git'.
2. Open the solution in Visual Studio Code or another C# IDE.
3. Open appsettings.json and set ConnectionStrings to your DataBase.
4. Build the solution to restore dependencies.

## DataBase
-use the assignment.doc attached to Create Orders and Agents tables and Insert initial data.
-use createStoredProcedures.txt to and run the commands to create 3 needed SP.

## Usage
1. Run the API using `dotnet run` in your terminal.
2. Open your browser or a tool like Postman and navigate to `http://localhost:5000/`.
3. Use one of the following endpoints to retrieve data:

###  3 Endpoints 
**HTTP Method:** GET
**Response Format:** JSON


#### 1. `/api/GetHighestAmountAgentCode?year=2021`

This endpoint get int year and returns the AGENT_CODE who has the highest sum  of ADVANCE_AMOUNT in the first quarter of the specific year.

#### 2. `/api/GetNthOrders?agents=A009,A004&&n=2`

This endpointget list string  agent_codes, int n and return list of orders, the Nth order for an agent.

#### 3. `/api/GetAgentsHavigNOrders?num=3&year=2021`

This endpoint get int n ,int year return a list of agents that have num or more orders in that year.

## Action Items
- Add input validations
- Hande exception and errors in all layers.
- Add loggs
- implement bonus assignment.
