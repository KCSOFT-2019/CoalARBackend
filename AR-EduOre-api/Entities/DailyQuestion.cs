using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("daily_question")]
    public class DailyQuestion
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime punch_in_date { get; set; }
        public bool if_punch_in { get; set; }

    }
}
