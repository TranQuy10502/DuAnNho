using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class NewsServices : IAllServices<NewsVM>
    {
        private readonly ApplicationBDContext _context;
        public NewsServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public NewsVM Add(NewsVM item)
        {
            var allnews = new News
            {
                Title=item.Title,
                Alias= item.Alias,
                Description= item.Description,
                Detail= item.Detail,
                Image= item.Image,
                IsActive = item.IsActive,
                CategoryId = item.CategoryId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
            _context.News.Add(allnews);
            _context.SaveChanges();
            var generatedId = allnews.Id;
            return new NewsVM
            {
                Id= generatedId,
                Title = item.Title,
                Alias = item.Alias,
                Description = item.Description,
                Detail = item.Detail,
                Image = item.Image,
                IsActive = item.IsActive,
                CategoryId = item.CategoryId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate

            };
        }

        public void Delete(int id)
        {
            var allnews = _context.News.SingleOrDefault(x => x.Id == id);
            if (allnews != null)
            {
                _context.News.Remove(allnews);
                _context.SaveChanges();
            }
        }

        public List<NewsVM> GetAll()
        {
            var Allnews = _context.News.Select(x => new NewsVM
            {
                Id = x.Id,
                Title = x.Title,
                Alias = x.Alias,
                Description = x.Description,
                IsActive = x.IsActive,
                Detail = x.Detail,
                Image = x.Image,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate

            });
            return Allnews.ToList();
        }

        public NewsVM GetById(int id)
        {
            var Allnews= _context.News.SingleOrDefault(x => x.Id == id);
            if (Allnews != null)
            {
                return new NewsVM
                {
                    Id = Allnews.Id,
                    Title = Allnews.Title,
                    Alias = Allnews.Alias,
                    Description = Allnews.Description,
                    IsActive = Allnews.IsActive,
                    Detail = Allnews.Detail,
                    Image = Allnews.Image,
                    CategoryId = Allnews.CategoryId,
                    CreatedDate = Allnews.CreatedDate,
                    ModifiedDate = Allnews.ModifiedDate
                };
            }
            return null;
        }

        public void Update(NewsVM item)
        {
            var allnews = _context.News.SingleOrDefault(x => x.Id == item.Id);
            allnews.Title = item.Title;
            allnews.Alias = item.Alias;
            allnews.Description = item.Description;
            allnews.Detail = item.Detail;
            allnews.Image = item.Image;
            allnews.IsActive = item.IsActive;
            allnews.CategoryId = item.CategoryId;
            allnews.CreatedDate = item.CreatedDate;
            allnews.ModifiedDate = item.ModifiedDate;

            _context.News.Update(allnews);
            _context.SaveChanges();
        }
    }
}
