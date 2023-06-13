using System.ComponentModel.DataAnnotations;

namespace WebDuAnNho.Models
{
    public class News : CommonAbstract
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn không để trống tiêu đề tin")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public bool? IsActive { get; set; }
        public int CategoryId { get; set; }


    }
}
