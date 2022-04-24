using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Entities
{
    [Table("user_information")]
    [Index(nameof(UserInformation.telephone), IsUnique = true)]
    public class UserInformation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

       
        public string telephone { get; set; }
        public string password { get; set; }
        public byte[]? head_portrait { get; set; }
        public bool sex { get; set; }
        public string name { get; set; }
        public string? department { get; set; }
        public string? lesson { get; set; }
        public byte? base_role_name { get; set; }
    }
}
