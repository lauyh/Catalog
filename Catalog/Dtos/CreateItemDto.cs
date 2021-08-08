using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [RangeAttribute(1, 10000)]
        public decimal Price { get; init; }
    }
}