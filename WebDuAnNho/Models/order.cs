using System.ComponentModel.DataAnnotations;

namespace WebDuAnNho.Models
{
    public class order : CommonAbstract
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }

        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ khổng để trống")]
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int PaymentMethodId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
