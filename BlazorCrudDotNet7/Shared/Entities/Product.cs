using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCrudDotNet7.Shared.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? Quantity { get; set; }
    public string Category { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}