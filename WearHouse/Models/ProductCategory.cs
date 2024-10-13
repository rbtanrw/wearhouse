using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WearHouse.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        [StringLength(10)]
        public string ProductID { get; set; }

        [MaxLength(50)] 
        public string Category { get; set;}

        [ForeignKey("DataUser")]
        public string UserID { get; set; }
    }
}
