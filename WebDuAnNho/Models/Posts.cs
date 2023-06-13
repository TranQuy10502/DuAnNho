using System.ComponentModel.DataAnnotations;

namespace WebDuAnNho.Models
{
    public class Posts:CommonAbstract
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public string Detail { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
