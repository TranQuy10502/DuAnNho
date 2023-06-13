using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using System.Web.Helpers;

namespace DuAnNho.Services
{
    public class UserServices :IAllServices<UserVM>
    {
        private readonly ApplicationBDContext _context;
        public UserServices(ApplicationBDContext context)
        {
            _context = context;
        }


        public UserVM Add(UserVM item)
        {
            var user = new User
            {               
                FullName = item.FullName,
                Phone = item.Phone,
                Email = item.Email,
                UserName = item.UserName,
                Password = item.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var generatedId = user.Id;
            return new UserVM
            {
                Id = generatedId ,
                FullName = item.FullName,
                Phone = item.Phone,
                Email = item.Email,
                UserName = item.UserName,
                Password = item.Password
            };
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<UserVM> GetAll()
        {
            var user = _context.Users.Select(x => new UserVM
            {
                Id = x.Id,
                FullName = x.FullName,
                Phone =x.Phone,
                Email = x.Email,
                UserName = x.UserName,
                Password = x.Password

            });
            return user.ToList();
        }

        public UserVM GetById(int id)
        {

            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user!= null)
            {
                return new UserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Phone = user.Phone,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password
                };
            }
            return null;
        }

        public void Update(UserVM item)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == item.Id);

            user.FullName = user.FullName;
            user.Phone = user.Phone;
            user.Email = user.Email;
            user.UserName = user.UserName;
            user.Password = user.Password;

            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
