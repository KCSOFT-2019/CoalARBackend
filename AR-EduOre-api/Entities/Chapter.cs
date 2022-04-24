using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR_EduOre_api.Entities;
[Table("chapter")]
public class Chapter
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id { get; set; }
    public Guid course_id { get; set; }
    public bool head { get; set; }
    public string name { get; set; }
    public Guid? next_id { get; set; }
}