using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class PostsServices : IAllServices<PostsVM>
    {
        private readonly ApplicationBDContext _context;
        public PostsServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public PostsVM Add(PostsVM item)
        {
            var allpost = new Posts
            {
                Title = item.Title,
               
                Description = item.Description,
                Detail = item.Detail,
                Image = item.Image,
                IsActive = item.IsActive,
                CategoryId = item.CategoryId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
            _context.Posts.Add(allpost);
            _context.SaveChanges();
            var generatedId = allpost.Id;
            return new PostsVM
            {
                Id = generatedId,
                Title = item.Title,             
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
            var allposts = _context.Posts.SingleOrDefault(x => x.Id == id);
            if (allposts != null)
            {
                _context.Posts.Remove(allposts);
                _context.SaveChanges();
            }
        }

        public List<PostsVM> GetAll()
        {
            var Allposts = _context.Posts.Select(x => new PostsVM
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsActive = x.IsActive,
                Detail = x.Detail,
                Image = x.Image,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate

            });
            return Allposts.ToList();
        }

        public PostsVM GetById(int id)
        {
            var allposts = _context.Posts.SingleOrDefault(x => x.Id == id);
            if (allposts != null)
            {
                return new PostsVM
                {
                    Id = allposts.Id,
                    Title = allposts.Title,                 
                    Description = allposts.Description,
                    IsActive = allposts.IsActive,
                    Detail = allposts.Detail,
                    Image = allposts.Image,
                    CategoryId = allposts.CategoryId,
                    CreatedDate = allposts.CreatedDate,
                    ModifiedDate = allposts.ModifiedDate
                };
            }
            return null;
        }

        public void Update(PostsVM item)
        {
            var allposts = _context.Posts.SingleOrDefault(x => x.Id == item.Id);
            allposts .Title = item.Title;
            allposts .Description = item.Description;
            allposts .Detail = item.Detail;
            allposts .Image = item.Image;
            allposts .IsActive = item.IsActive;
            allposts .CategoryId = item.CategoryId;
            allposts .CreatedDate = item.CreatedDate;
            allposts.ModifiedDate = item.ModifiedDate;

            _context.Posts.Update(allposts);
            _context.SaveChanges();
        }
    }
}
