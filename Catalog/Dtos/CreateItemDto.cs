using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; init; }
    }
}