using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Event
    {
        public Guid? Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<EventKrapfen> Krapfen { get; set; }
    }
}