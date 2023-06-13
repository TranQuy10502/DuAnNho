using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DuAnNho.Models.EF
{
    [Table("tb_Supplier")]
    public class Supplier
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(150)]       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        [StringLength(10)]

        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string Phone { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
    }
}
