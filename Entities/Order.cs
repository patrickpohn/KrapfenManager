using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Order
    {
        public Guid? Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string OrderName { get; set; }
        [MaxLength(200)]
        [MinLength(2)]
        public string Description { get; set; }
        public DateTime PickUpTime { get; set; }
        public List<KrapfenOrder> KrapfenOrder { get; set; }
    }
}