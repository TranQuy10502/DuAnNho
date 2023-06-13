using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DuAnNho.Models.ViewModel
{
    public class NewsVM : CommonAbstract
    {
        public int Id { get; set; }      
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }       
        public string Detail { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
