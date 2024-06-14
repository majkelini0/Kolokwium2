using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;

[Table("character_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class Character_Titles
{
    public int CharacterId { get; set; }
    
    public int TitleId { get; set; }
    
    [Required]
    public DateTime AcquiredAt { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public Characters Character { get; set; } = null!;
    
    [ForeignKey(nameof(TitleId))]
    public Titles Title { get; set; } = null!;
}