using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities
{
    [Table("daily_question_bank")]
    public class DailyQuestionBank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DailyQuestionID { get; set; }

        public string daily_stem_description { get; set; }

        public string daily_A_options { get; set; }

        public string daily_B_options { get; set; }

        public string daily_C_options { get; set; }

        public string daily_D_options { get; set; }

    }
}
