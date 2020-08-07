﻿using System;
 using System.ComponentModel.DataAnnotations;

 namespace Entities
{
    public class KrapfenOrder
    {
        public Guid Id { get; set; }
        [Required]
        public Guid KrapfenId { get; set; }
        public Guid OrderId { get; set; }
    }
}