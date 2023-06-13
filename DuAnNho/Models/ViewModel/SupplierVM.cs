using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DuAnNho.Models.ViewModel
{
    public class SupplierVM
    {
        public int SupplierId { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }  
        public string Phone { get; set; }    
        public string Detail { get; set; }
    }
}
