using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentsService.Models
{
    [Table("AGENTS")]
    public  class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AGENT_CODE { get; set; }
        public string? AGENT_NAME { get; set; }
        public string? WORKING_AREA { get; set; }
        public int? COMMISSION { get; set; }
        public string? PHONE_NO { get; set; }
        public string? COUNTRY  { get; set; }

    }

   
    }
