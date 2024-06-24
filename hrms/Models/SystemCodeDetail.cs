using System.ComponentModel.DataAnnotations;

namespace hrms.Models
{
    public class SystemCodeDetail: UserActivity
    {
        [Key]

        public int Id { get; set; }

        public int SystemCodeId { get; set; }

        public SystemCode SystemCode { get; set; }

        public string Code { get; set; }

        public String Description { get; set; }

        public String? Duration {get; set;}

        public int DurationId {get; set;}
        
        public int? OrderNo { get; set; }
    
    }
}
