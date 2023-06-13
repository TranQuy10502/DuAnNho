using System.ComponentModel.DataAnnotations;

namespace DuAnNho.Models.ViewModel
{
    public class ProductCategoryVM : CommonAbstract
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
      
        public string Alias { get; set; }
        public string Image
        {
            get; set;
        }
     }
}
