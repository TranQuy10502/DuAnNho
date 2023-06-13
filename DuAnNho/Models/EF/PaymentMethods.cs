using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuAnNho.Models.EF
{
    [Table("tb_PaymentMethods")]
    public class PaymentMethods
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
