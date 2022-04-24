using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("student_collection_question")]
    public class StudentCollection
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid question_chocie_id { get; set; }
        public bool collection_question_choice { get; set; }
        public int collection_question_choice_id { get; set; }
        public bool collection_examination_paper { get; set; }
        public int daily_question_id { get; set; }
        public bool collection_daily_question { get; set; }
    }
}
