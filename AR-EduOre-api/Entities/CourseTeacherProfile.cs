using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("course_teacher_profile")]
    public class CourseTeacherProfile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? online_id { get; set; }
        public Guid? open_id { get; set; }
        public Guid? offline_id { get; set; }
        
        
        //public string teacher_name { get; set; }
        //public string? teacher_profile { get; set; }
        //public byte[]? teacher_picture { get; set; }

    }
}
