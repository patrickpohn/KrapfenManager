using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string OrderName { get; set; }
        [MaxLength(200)]
        [MinLength(2)]
        public string Description { get; set; }
        public DateTime PickUpTime { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public List<KrapfenOrder> KrapfenOrder { get; set; }

        public Order()
        {
            KrapfenOrder = new List<KrapfenOrder>();
        }
    }
}