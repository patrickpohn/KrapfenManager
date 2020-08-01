using System;
using System.Collections.Generic;

namespace Entities
{
    public class KrapfenOrder
    {
        public Guid Id { get; set; }
        public List<Krapfen> Krapfen { get; set; }
    }
}