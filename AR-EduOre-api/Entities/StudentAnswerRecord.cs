using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("student_answer_record")]
    public class StudentAnswerRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentAnswerId { get; set;}

        public Guid daily_question_id { get; set;}
        public string daily_question_answer { get; set;}
        public bool daily_question_answer_right { get; set;}
        public int examination_paper_id { get; set;}
        public bool finish { get; set;}

        public int question_choice_id { get; set;}
        public string question_choice_answer { get; set;}
        public bool question_choice_answer_right { get;set;}
        public int discussion_question_choice_id { get; set;}
        public string discussion_question_answer { get;set;}
        public bool discussion_question_answer_right { get; set;}
    }
}
