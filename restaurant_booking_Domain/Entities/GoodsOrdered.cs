using System;
using System.ComponentModel.DataAnnotations;

namespace restaurant_booking_Domain.Entities
{
    public class GoodsOrdered
    {
        [Key]
        public string AppUsersId { get; set; }
        public AppUsers AppUser { get; set; }
        public GadgetProduct Product { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal TotalProductPrice { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}