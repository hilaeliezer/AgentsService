namespace AgentsService.Models
{
    public class GetHighestAmountAgentCode_Result
    {
        public string AGENT_CODE { get; set; }

    }
    public class GetAgentsHavigNOrders_Result
    {
        public string AGENT_CODE { get; set; }
        public string? AGENT_NAME { get; set; }
        public string? PHONE_NO { get; set; }

    }
}
