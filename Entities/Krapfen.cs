using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Krapfen
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,5)]
        public double Price { get; set; }
        [IsBase64]
        public string Image { get; set; }
    }
    
    public class IsBase64 : ValidationAttribute  
    {  
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (validationContext.ObjectInstance == null) return new ValidationResult("Value is null");
                var k = (Krapfen) validationContext.ObjectInstance;
                if(string.IsNullOrEmpty(k.Image)) return ValidationResult.Success;
                Convert.FromBase64String(k.Image);
                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Image is no Base64 String");
            }
        }  
    }  
}