using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing;

namespace DuAnNho.Services
{
    public class ProductServices : IAllServices<ProductVM>
    {
        private readonly ApplicationBDContext _context;
        public ProductServices(ApplicationBDContext context)
        {
            _context = context;
        }
        public ProductVM Add(ProductVM item)
        {
            var product = new Product
            {
                Title = item.Title,
                Alias = item.Alias,
                ProductCode = item.ProductCode,
                Description = item.Description,
                Detail = item.Detail,
                Image = item.Image,
                OriginalPrice = item.OriginalPrice,
                Price = item.Price,
                Quantity = item.Quantity,
                Size = item.Size,
                IsHome = item.IsHome,
                IsSale = item.IsSale,
                IsHot = item.IsHot,
                IsActive = item.IsActive,
                ViewCount = item.ViewCount,
                ProductCategoryId = item.ProductCategoryId,
                SupplierId = item.SupplierId,
                MaterialId = item.MaterialId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            var generatedId = product.Id;
            return new ProductVM
            {
                Id= generatedId,
                Title = item.Title,
                Alias = item.Alias,
                ProductCode = item.ProductCode,
                Description = item.Description,
                Detail = item.Detail,
                Image = item.Image,
                OriginalPrice = item.OriginalPrice,
                Price = item.Price,
                Quantity = item.Quantity,
                Size = item.Size,
                IsHome = item.IsHome,
                IsSale = item.IsSale,
                IsHot = item.IsHot,
                IsActive = item.IsActive,
                ViewCount = item.ViewCount,
                ProductCategoryId = item.ProductCategoryId,
                SupplierId = item.SupplierId,
                MaterialId = item.MaterialId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
            };
        }

        public void Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<ProductVM> GetAll()
        {
            var product = _context.Products.Select(item => new ProductVM
            {
                Id = item.Id,
                Title = item.Title,
                Alias = item.Alias,
                ProductCode = item.ProductCode,
                Description = item.Description,
                Detail = item.Detail,
                Image = item.Image,
                OriginalPrice = item.OriginalPrice,
                Price = item.Price,
                Quantity = item.Quantity,
                Size = item.Size,
                IsHome = item.IsHome,
                IsSale = item.IsSale,
                IsHot = item.IsHot,
                IsActive = item.IsActive,
                ViewCount = item.ViewCount,
                ProductCategoryId = item.ProductCategoryId,
                SupplierId = item.SupplierId,
                MaterialId = item.MaterialId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate

            });
            return product.ToList();
        }

        public ProductVM GetById(int id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return new ProductVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    Alias = item.Alias,
                    ProductCode = item.ProductCode,
                    Description = item.Description,
                    Detail = item.Detail,
                    Image = item.Image,
                    OriginalPrice = item.OriginalPrice,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Size = item.Size,
                    IsHome = item.IsHome,
                    IsSale = item.IsSale,
                    IsHot = item.IsHot,
                    IsActive = item.IsActive,
                    ViewCount = item.ViewCount,
                    ProductCategoryId = item.ProductCategoryId,
                    SupplierId = item.SupplierId,
                    MaterialId = item.MaterialId,
                    CreatedDate = item.CreatedDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductCategory = _context.ProductCategories.Find(item.ProductCategoryId)
                };
            }
            return null;
        }

        public void Update(ProductVM item)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == item.Id);
            if (product == null)
            {
               
                throw new InvalidOperationException("Không tìm thấy đối tượng ChucVu để cập nhật.");

            }
            product.Title = item.Title;
            product.Alias = item.Alias;
            product.ProductCode = item.ProductCode;
            product.Description = item.Description;
            product.Detail = item.Detail;
            product.Image = item.Image;
            product.OriginalPrice = item.OriginalPrice;
            product.Price = item.Price;
            product.Quantity = item.Quantity;
            product.Size = item.Size;
            product.IsHome = item.IsHome;
            product.IsSale = item.IsSale;
            product.IsHot = item.IsHot;
            product.IsActive = item.IsActive;
            product.ViewCount = item.ViewCount;
            product.ProductCategoryId = item.ProductCategoryId;
            product.SupplierId = item.SupplierId;
            product.MaterialId = item.MaterialId;
            product.CreatedDate = item.CreatedDate;
            product.ModifiedDate = item.ModifiedDate;

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
