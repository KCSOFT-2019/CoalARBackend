using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("open_course")]
    public class OpenCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OpenCourseId { get; set; }
        public string open_name { get; set; }
        public int open_course_link { get; set; }
    }
}
