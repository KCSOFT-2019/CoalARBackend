using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("online_course_evaluation")]
    public class OnlineCourseEvaluation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid online_course_id { get; set; }
        public string online_evaluation_text { get; set; }
        public byte[] online_evaluation_picture { get; set; }
        public DateTime online_evaluation_date { get; set; }
        public int online_link { get; set; }
    }
}
