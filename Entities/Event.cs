using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public List<EventKrapfen> Krapfen { get; set; }

        public Event()
        {
            Krapfen =new List<EventKrapfen>();
        }
    }
}