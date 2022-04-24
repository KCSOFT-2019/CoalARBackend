using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("question_choice_bank")]
    public class QuestionChoiceBank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid examinationPaperID { get; set; }
        public byte questionScore { get; set; }

        public string questionChoiceDescription { get; set; }
        public string A_option { get; set; }
        public string B_option { get; set; }
        public string C_option { get; set; }
        public string D_option { get; set; }
        public string question_choic_analysis { get; set; }

    }
}
