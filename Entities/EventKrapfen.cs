using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EventKrapfen
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid KrapfenId { get; set; }
    }
}