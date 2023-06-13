using DuAnNho.Models.EF;
using System.ComponentModel.DataAnnotations;

namespace DuAnNho.Models.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }     
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User ToUser()
        {
            return new User
            {
                Id = Id,
                FullName = FullName,
                Phone = Phone,
                Email = Email,
                UserName = UserName,
                Password = Password
            };
        }
    }
}
