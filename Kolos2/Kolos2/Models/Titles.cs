using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;

[Table("titles")]
[PrimaryKey(nameof(Id))]
public class Titles
{
    public int Id { get; set; }
    
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    
    public ICollection<Character_Titles> Character_TitlesNav { get; set; } = new HashSet<Character_Titles>();
}