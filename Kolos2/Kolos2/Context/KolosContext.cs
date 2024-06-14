using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Context;

public partial class KolosContext : DbContext
{
    public KolosContext()
    {
    }

    public KolosContext(DbContextOptions<KolosContext> options)
        : base(options)
    {
    }
    
    public DbSet<Items> Items { get; set; }
    public DbSet<Backpacks> Backpacks { get; set; }
    public DbSet<Characters> Characters { get; set; }
    
    public DbSet<Character_Titles> Character_Titles { get; set; }
    
    public DbSet<Titles> Titles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        
        modelBuilder.Entity<Items>().HasData(
            new Items
            {
                Id = 1,
                Name = "Sword",
                Weight = 10
            },
            new Items
            {
                Id = 2,
                Name = "Shield",
                Weight = 15
            },
            new Items
            {
                Id = 3,
                Name = "Bow",
                Weight = 5
            }
        );

        modelBuilder.Entity<Characters>().HasData(
            new Characters
            {
                Id = 1,
                FirstName = "Geralt",
                LastName = "From Rivia",
                CurrentWeight = 0,
                MaxWeight = 300
            },
            new Characters
            {
                Id = 2,
                FirstName = "Ciri",
                LastName = "From Cintra",
                CurrentWeight = 0,
                MaxWeight = 60
            },
            new Characters
            {
                Id = 3,
                FirstName = "Yennefer",
                LastName = "From Vengerberg",
                CurrentWeight = 0,
                MaxWeight = 70
            },
            new Characters
            {
                Id = 4,
                FirstName = "Triss",
                LastName = "Merigold",
                CurrentWeight = 0,
                MaxWeight = 50
            },
            new Characters
            {
                Id = 5,
                FirstName = "Jaskier",
                LastName = "The Bard",
                CurrentWeight = 0,
                MaxWeight = 30
            }
        );

        modelBuilder.Entity<Titles>().HasData(
            new Titles
            {
                Id = 1,
                Name = "Witcher"
            },
            new Titles
            {
                Id = 2,
                Name = "Sorceress"
            },
            new Titles
            {
                Id = 3,
                Name = "Bard"
            },
            new Titles
            {
                Id = 4,
                Name = "Queen"
            },
            new Titles
            {
                Id = 5,
                Name = "King"
            },
            new Titles
            {
                Id = 6,
                Name = "Prince"
            },
            new Titles
            {
                Id = 7,
                Name = "White Wolf"
            }
        );

        modelBuilder.Entity<Character_Titles>().HasData(
            new Character_Titles
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Now
            },
            new Character_Titles
            {
                CharacterId = 2,
                TitleId = 4,
                AcquiredAt = DateTime.Now
            },
            new Character_Titles
            {
                CharacterId = 3,
                TitleId = 2,
                AcquiredAt = DateTime.Now
            },
            new Character_Titles
            {
                CharacterId = 4,
                TitleId = 2,
                AcquiredAt = DateTime.Now
            },
            new Character_Titles
            {
                CharacterId = 5,
                TitleId = 3,
                AcquiredAt = DateTime.Now
            },
            new Character_Titles
            {
                CharacterId = 1,
                TitleId = 7,
                AcquiredAt = DateTime.Now
            }
        );

        // modelBuilder.Entity<Backpacks>().HasData(
        //     new Backpacks
        //     {
        //         CharacterId = 1,
        //         ItemId = 1,
        //         Amount = 1
        //     },
        //     new Backpacks
        //     {
        //         CharacterId = 1,
        //         ItemId = 2,
        //         Amount = 1
        //     },
        //     new Backpacks
        //     {
        //         CharacterId = 1,
        //         ItemId = 3,
        //         Amount = 1
        //     }
        // );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
