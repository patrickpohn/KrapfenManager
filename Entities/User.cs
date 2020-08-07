using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}