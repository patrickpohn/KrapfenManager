using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class EventKrapfen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [NotMapped]
        public Guid Event { get; set; }
        [Required]
        public Guid Krapfen { get; set; }
    }
}