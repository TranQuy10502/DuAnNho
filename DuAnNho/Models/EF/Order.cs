using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuAnNho.Models.EF
{
    [Table("tb_Order")]
    public class Order : CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();           
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }

        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ khổng để trống")]
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethodId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public decimal ShippingCost { get; set; }
        public virtual Customer Customer { get; set; }      
        public virtual User Users { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
