using System;
using System.Collections.Generic;

namespace Entities
{
    public class Order
    {
        public Guid? Id { get; set; }
        public string OrderName { get; set; }
        public DateTime Time { get; set; }
        public List<Krapfen> Krapfens { get; set; }
    }
}