using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.CodeAnalysis;

namespace DuAnNho.Services
{
    public class ProductImageServices : IAllServices<ProductImageVM>
    {
        private readonly ApplicationBDContext _context;
        public ProductImageServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public ProductImageVM Add(ProductImageVM item)
        {
            var productImg = new ProductImage
            {
                 ProductId= item.ProductId,
                Image = item.Image,
                IsDefault = item.IsDefault
            };
            _context.ProductImages.Add(productImg);
            _context.SaveChanges();
            var generatedId = productImg.Id;
            return new ProductImageVM
            {
                Id = generatedId,
                ProductId = item.ProductId,
                Image = item.Image,
                IsDefault = item.IsDefault
            };
        }

        public void Delete(int id)
        {
            var productImg = _context.ProductImages.SingleOrDefault(c => id == c.Id);
            if (productImg != null)
            {
                _context.ProductImages.Remove(productImg);
                _context.SaveChanges();
            }
        }

    



        public List<ProductImageVM> GetAll()
        {
            var productImg = _context.ProductImages.Select(x => new ProductImageVM
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Image = x.Image,
                IsDefault = x.IsDefault
            });
            return productImg.ToList();
        }

        public ProductImageVM GetById(int id)
        {
            var productImg = _context.ProductImages.SingleOrDefault(x => x.Id == id);
            if (productImg != null)
            {
                return new ProductImageVM
                {
                    Id = productImg.Id,
                    ProductId = productImg.ProductId,
                    Image = productImg.Image,
                    IsDefault = productImg.IsDefault
                };
                
            }
            return null;
        }

        public void Update(ProductImageVM item)
        {
            var productImd = _context.ProductImages.SingleOrDefault(x => x.Id == item.Id);

           productImd.ProductId = item.ProductId;
           productImd.Image = item.Image;
           productImd.IsDefault = item.IsDefault;


            _context.ProductImages.Update(productImd);
            _context.SaveChanges();
        }
    }
}
