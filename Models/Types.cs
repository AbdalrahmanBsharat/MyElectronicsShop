using System.ComponentModel.DataAnnotations;

namespace MyElectronicShop.Models
{
    public class Types
    {
        [Key]
        public string TypeId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }
}
