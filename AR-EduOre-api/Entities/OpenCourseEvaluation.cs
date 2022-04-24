using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("open_course_evaluaton")]
    public class OpenCourseEvaluation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid OpenCourseId { get; set; }
        public string open_evaluation_text { get; set; }
        public byte[] open_evalution_blob { get; set; }
        public DateTime open_evaluation_date { get; set; }

    }
}
