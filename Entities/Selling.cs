using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Selling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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