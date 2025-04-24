using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyElectronicShop.Models
{
    public class Product
    {
        [Key]
        public int PrId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public double? Price { get; set; }

        [Required]
        public string url { get; set; } = string.Empty;

        [Required]
        public string TypeId { get; set; } = string.Empty;

        [ValidateNever]
        public Types Type { get; set; } = null!;

        public string Slug =>
        Name?.Replace(' ', '-').ToLower() + '-' + PrId.ToString();
    }
}
