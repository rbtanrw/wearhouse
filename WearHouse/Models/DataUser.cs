using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WearHouse.Models
{
    [Table("DataUser")]
    public class DataUser
    {
        [Key]
        [StringLength(5)]
        public string UserID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}
