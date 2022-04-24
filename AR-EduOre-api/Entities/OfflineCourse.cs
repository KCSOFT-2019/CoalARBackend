using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("offline_course")]
    public class OfflineCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string offline_name { get; set;}
        public byte[]? offline_picture { get; set; }
        public DateTime offline_begin_date { get; set; }
        public DateTime offline_end_date { get;  set; }

        public byte offline_week { get; set; }
        public string offline_space { get; set; }
        public DateTime offline_enroll_begin_date { get; set; }
        public DateTime Offline_enroll_end_date { get; set; }
        public bool offline_course_if { get; set; }
    }
}
