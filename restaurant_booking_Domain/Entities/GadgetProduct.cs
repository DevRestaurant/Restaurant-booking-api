﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_booking_Domain.Entities
{
    public class GadgetProduct
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public  decimal Price { get; set; }
        public  string Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
