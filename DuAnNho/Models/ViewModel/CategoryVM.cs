namespace DuAnNho.Models.ViewModel
{
    public class CategoryVM:CommonAbstract
    {
        public int Id { get; set; }      
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }       
        public bool IsActive { get; set; }
        public int Position { get; set; }
    }
}
