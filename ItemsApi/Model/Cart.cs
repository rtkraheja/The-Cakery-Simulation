﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsApi.Models
{
    public class Cart
    {
        [Key]
        
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }

 

        public Item item { get; set; }


    }
}
