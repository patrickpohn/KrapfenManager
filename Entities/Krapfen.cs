using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Krapfen
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}