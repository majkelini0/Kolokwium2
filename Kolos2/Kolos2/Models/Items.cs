using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;

[Table("items")]
[PrimaryKey(nameof(Id))]
public class Items
{
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    
    [Required] public int Weight { get; set; }

    public ICollection<Backpacks> BackpacksNav { get; set; } = new HashSet<Backpacks>();
}