using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Selling
    {
        public Guid? Id { get; set; }
        public Order Order { get; set; }
        [Required]
        public double Price { get; set; }
        public double Tip { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public User User { get; set; }
    }
}