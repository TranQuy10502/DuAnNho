using System.ComponentModel.DataAnnotations;

namespace WebDuAnNho.Models
{
    public class Product : CommonAbstract
    {
        public Product()
        {
            this.ProductImages = new HashSet<ProductImage>();
            this.ProductCategory = new ProductCategory();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }
        public string Description { get; set; }

        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; } = "";
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }

        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public int ProductCategoryId { get; set; }
        public int SupplierId { get; set; }
        public int MaterialId { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public  ICollection<ProductImage> ProductImages { get; set; }
    }
}
