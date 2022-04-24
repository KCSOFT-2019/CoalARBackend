using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("discussion_question_bank")]
    public class DiscussionQuestionBank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? daily_question_id { get; set; }
        public Guid? discussion_question_choice_id { get; set; }
        public Byte discussion_question_score { get; set; }

        public string discussion_question_description { get; set; }
        public string discussion_question_analysis { get; set; }
    }
}
