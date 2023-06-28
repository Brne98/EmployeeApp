using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCrudDotNet7.Shared
{
    public class Product
    {
        public int Id { get; set; }
        
        public required string Title { get; set; }

        public string Category { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
