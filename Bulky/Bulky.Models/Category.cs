using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required, StringLength(60, MinimumLength = 3)]
    public string? Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
    public int DisplayOrder { get; set; } // => Buyurtmalarni korsatish.
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}