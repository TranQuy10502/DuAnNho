﻿using System.ComponentModel.DataAnnotations;

namespace DuAnNho.Models.ViewModel
{
    public class PaymentMethodsVM
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
