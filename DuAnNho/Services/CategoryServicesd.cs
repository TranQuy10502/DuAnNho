using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DuAnNho.Services
{
    public class CategoryServicesd : IAllServices<CategoryVM>
    {
        private readonly ApplicationBDContext _context;
        public CategoryServicesd(ApplicationBDContext context)
        {
            _context = context;
        }
        public CategoryVM Add(CategoryVM item)
        {
            var category = new Category
            {
                Title = item.Title,
                Alias = item.Alias,
                Description = item.Description,
                IsActive = item.IsActive,
                Position = item.Position,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate

            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            var generatedId = category.Id;
            return new CategoryVM
            {
                Id = generatedId,
                Title = item.Title,
                Alias = item.Alias,
                Description = item.Description,
                IsActive = item.IsActive,
                Position = item.Position,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var category = _context.Categories.Select(x => new CategoryVM
            {
                Id = x.Id,
                Title = x.Title,
                Alias = x.Alias,
                Description = x.Description,
                IsActive = x.IsActive,
                Position = x.Position,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate

            });
            return category.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);
            if(category != null)
            {
                return new CategoryVM
                {
                    Id = category.Id,
                    Title = category.Title,
                    Alias = category.Alias,
                    Description = category.Description,
                    IsActive = category.IsActive,
                    Position = category.Position,
                    CreatedDate = category.CreatedDate,
                    ModifiedDate = category.ModifiedDate
                };
            }
            return null;
        }

        public void Update(CategoryVM item)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == item.Id);

            category .Title = item.Title;
            category .Alias = item.Alias;
            category .Description = item.Description;
            category .IsActive = item.IsActive;
            category .Position = item.Position;
            category .CreatedDate = item.CreatedDate;
            category.ModifiedDate = item.ModifiedDate;

            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
