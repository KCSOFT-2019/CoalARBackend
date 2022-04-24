using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("online_course")]
    public class OnlineCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string online_name { get; set; }
        public byte[]? online_picture { get; set; }

        public DateTime online_begin_time { get; set; }
        public DateTime online_end_time { get; set; }
        public byte online_week { get; set; }
        public DateTime online_enroll_begin_time { get; set; }
        public DateTime online_enroll_end_time { get; set; }

        public bool online_course_if { get; set; }
        
        public byte online_course_status { get; set; }
     }
}
