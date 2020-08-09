﻿using System;
 using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;

 namespace Entities
{
    public class KrapfenOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid Krapfen { get; set; }
        [NotMapped]
        public Guid Order { get; set; }
    }
}