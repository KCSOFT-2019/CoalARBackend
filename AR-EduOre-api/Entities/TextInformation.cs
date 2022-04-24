using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("text_information")]
    public class TextInformation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string TextContent { get; set; }
        public DateTime begin_Time { get; set; }
        public DateTime end_Time { get; set; }

        public TimeSpan clock_in_time {get; set;}

        public TimeSpan clock_in_reminder_time { get; set; }

        public bool clock_in_Monday { get; set; }

        public bool clock_in_Tuesday { get; set; }

        public bool clock_in_Wednesday { get; set; }
        public bool clock_in_Thursday { get; set; }
        public bool clock_in_Friday { get; set; }
        public bool clock_in_Saturday { get; set; }

        public bool clock_in_Sunday { get; set; }

        public string text_remark { get; set; }

        public bool clock_in_finish { get; set; }



    }
}
