using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cake_Shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        
        [TempData]
        public string StatusMessage { get; set; }
    }
}
