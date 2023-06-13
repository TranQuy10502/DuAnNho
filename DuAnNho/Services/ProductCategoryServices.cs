using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class ProductCategoryServices : IAllServices<ProductCategoryVM>
    {
        private readonly ApplicationBDContext _context;
        public ProductCategoryServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public ProductCategoryVM Add(ProductCategoryVM item)
        {
            var productCategorys = new ProductCategory
            {
                Title = item.Title,
                Alias = item.Alias,
                Image = item.Image,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
            _context.ProductCategories.Add(productCategorys);
            _context.SaveChanges();
            var generatedId = productCategorys.Id;
            return new ProductCategoryVM
            {
                Id= generatedId,
                Title = item.Title,
                Alias = item.Alias,
                Image = item.Image,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
        }

        public void Delete(int id)
        {                
            var allposts = _context.ProductCategories.SingleOrDefault(x => x.Id == id);
            if (allposts != null)
            {
                _context.ProductCategories.Remove(allposts);
                _context.SaveChanges();
            }
        }

        public List<ProductCategoryVM> GetAll()
        {
            var productCategory = _context.ProductCategories.Select(c => new ProductCategoryVM
            {
                Id = c.Id,
                Title = c.Title,
                Alias = c.Alias,
                Image = c.Image,
                CreatedDate =c.CreatedDate,
                ModifiedDate =c.ModifiedDate
            });
            return productCategory.ToList();

        }

        public ProductCategoryVM GetById(int id)
        {
            var productCategory = _context.ProductCategories.SingleOrDefault(c => id == c.Id);
            if (productCategory != null)
            {
                return new ProductCategoryVM
                {
                    Id = productCategory.Id,
                    Title = productCategory.Title,
                    Alias = productCategory.Alias,
                    Image = productCategory.Image,
                    CreatedDate = productCategory.CreatedDate,
                    ModifiedDate = productCategory.ModifiedDate
                };
            }
            return null;
        }

        public void Update(ProductCategoryVM item)
        {
            var productCategory = _context.ProductCategories.SingleOrDefault(c => c.Id == item.Id);
            
            productCategory.Title = item.Title;
            productCategory.Alias = item.Alias;
            productCategory.Image = item.Image;
            productCategory.CreatedDate = item.CreatedDate;
            productCategory.ModifiedDate = item.ModifiedDate;
            _context.ProductCategories.Update(productCategory);
            _context.SaveChanges();

        }

    }
}
