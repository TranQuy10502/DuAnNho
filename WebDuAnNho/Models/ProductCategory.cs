using System.ComponentModel.DataAnnotations;

namespace WebDuAnNho.Models
{
    public class ProductCategory : CommonAbstract
    {
        public ProductCategory()
        {
            Title = Alias = Image = "";
        }
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = "";
        [Required]
        [StringLength(150)]
        public string Alias { get; set; } = "";
        public string Image { get; set; } = "";

    }
}
