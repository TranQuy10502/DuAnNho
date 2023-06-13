namespace DuAnNho.Models.ViewModel
{
    public class OrderVM : CommonAbstract
    {
        public int Id { get; set; }
       
        public string Code { get; set; }  
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public decimal ShippingCost { get; set; }

        public string PaymentMethodId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
