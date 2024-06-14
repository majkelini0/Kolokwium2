using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;

[Table("characters")]
[PrimaryKey(nameof(Id))]
public class Characters
{
    public int Id { get; set; }
    
    [Required] [MaxLength(50)] public string FirstName { get; set; } = string.Empty;
    
    [Required] [MaxLength(120)] public string LastName { get; set; } = string.Empty;
    
    public int CurrentWeight { get; set; }
    
    public int MaxWeight { get; set; }
    
    public ICollection<Backpacks> BackpacksNav { get; set; } = new HashSet<Backpacks>();
    
    public ICollection<Character_Titles> Character_TitlesNav { get; set; } = new HashSet<Character_Titles>();
}