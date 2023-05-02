using AgentsService.DBContext;
using AgentsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System;
using System.Collections.Immutable;

namespace AgentsService.Controller
{
    [Route("api/")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly Context _dbContext;
        public DataController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            if (_dbContext.Agents == null)
            {
                return NotFound();
            }

            var agents = await _dbContext.Agents.ToListAsync();
            return agents;
        }

        //get int year return The AGENT_CODE who has the highest sum   
        // of ADVANCE_AMOUNT in the first quarter of the specific year
        //usage: api/GetHighestAmountAgentCode?year=2021
        [HttpGet("GetHighestAmountAgentCode")]
        public IEnumerable<GetHighestAmountAgentCode_Result> GetHighestAmountAgentCode([FromQuery] int year)
        {
            try
            {
                var agents = _dbContext.GetHighestAmountAgentCode(year);
                return agents;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        //get list string  agent_codes, int n and return  list of orders, the Nth order for an agent
        //usage: api/GetNthOrders?agents=A009,A004&&n=2
        [HttpGet("GetNthOrders")]
        public IEnumerable<Order> GetNthOrders([FromQuery] string agents, int n)
        {
            try
            {
                var orders = _dbContext.GetNthOrders(agents, n);
                return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //get int n ,int year return a list of agents that have num or more orders in that year 
        //usage: api/GetAgentsHavigNOrders?num=3&year=2021
        [HttpGet("GetAgentsHavigNOrders")]
        public IEnumerable<GetAgentsHavigNOrders_Result> GetAgentsHavigNOrders([FromQuery] int num, int year)
        {
            try
            {
                var agents = _dbContext.GetAgentsHavigNOrders(3, 2021);
                return agents;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw ;
            }
        }
    }

}