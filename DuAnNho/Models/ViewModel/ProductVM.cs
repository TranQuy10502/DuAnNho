using DuAnNho.Models.EF;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DuAnNho.Models.ViewModel
{
    public class ProductVM : CommonAbstract
    {
        public ProductVM()
        {
            this.ProductImages = new HashSet<ProductImage>();
            this.ProductCategory = new ProductCategory();
        }
        public int Id { get; set; }
     
        public string Title { get; set; }    
        public string Alias { get; set; }     
        public string ProductCode { get; set; }
        public string Description { get; set; }

        public string Detail { get; set; }
        public string Image { get; set; }
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
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
