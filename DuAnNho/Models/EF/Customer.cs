using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuAnNho.Models.EF
{
    [Table("tb_Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(150)]
        public string CustomerName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Địa chỉ khổng để trống")]
        public string Address { get; set; }
        public string Password { get; set; }
        [StringLength(10)]

        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string PhoneNumber { get; set; }
        public string Points { get; set; }

        public virtual ICollection<Order> orders { get; set; }
    }
}
