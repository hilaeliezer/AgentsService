using AgentsService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AgentsService.DBContext
{
   

public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Order> Orders { get; set; }

        public virtual DbSet<GetHighestAmountAgentCode_Result> GetHighestAmountAgentCode_Result { get; set; }
        public virtual DbSet<GetAgentsHavigNOrders_Result> GetAgentsHavigNOrders_Result { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().ToTable("AGENTS");
            modelBuilder.Entity<Order>().ToTable("ORDERS");
            modelBuilder.Entity<GetHighestAmountAgentCode_Result>(entity =>
                entity.HasKey(e => e.AGENT_CODE));
            modelBuilder.Entity<GetAgentsHavigNOrders_Result>(entity =>
               entity.HasKey(e => e.AGENT_CODE));

        }
        
        public IEnumerable<GetHighestAmountAgentCode_Result> GetHighestAmountAgentCode(int year)
        {
            return this.GetHighestAmountAgentCode_Result
                .FromSqlRaw($"exec SelectAgentHighestAmount @Year= {year}")
                .ToArray();
        }
        public IEnumerable<Order> GetNthOrders(string agentsList,int num)
        {

            var l = new SqlParameter("@Agents_list", agentsList);
            var n = new SqlParameter("@Num", num);
            return this.Orders
                .FromSqlRaw($"exec SelectNthAgentOrder @Agents_list, @Num",  l, n )
                .ToArray();
        }
      
        public IEnumerable<GetAgentsHavigNOrders_Result> GetAgentsHavigNOrders(int num, int year)
        {
            return this.GetAgentsHavigNOrders_Result
                .FromSqlRaw($"exec SelectAgentsYearNOrders  @Num= {num}, @Year= {year}")
                .ToArray();
        }
    }
 

}
