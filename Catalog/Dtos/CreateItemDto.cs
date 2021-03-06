using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
    {
        public CreateItemDto(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [RangeAttribute(1, 10000)]
        public decimal Price { get; init; }
    }
}