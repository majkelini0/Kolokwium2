using Kolos2.Context;
using Kolos2.Models;
using Kolos2.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Services;

public class DbService : IDbService
{
    private readonly KolosContext _context;

    public DbService(KolosContext context)
    {
        _context = context;
    }

    public async Task<Characters?> GetCharacterByIdAsync(int id)
    {
        return await _context
            .Characters
            .Include(x => x.BackpacksNav)
            .ThenInclude(x => x.Item)
            .Include(y => y.Character_TitlesNav)
            .ThenInclude(y => y.Title)
            .Where(z => z.Id == id)
            .FirstOrDefaultAsync();
    }

    public Object GetCharacterInfoResponse(Characters character)
    {
        var res = new
        {
            firstName = character.FirstName,
            lastName = character.LastName,
            currentWeight = character.CurrentWeight,
            maxWeight = character.MaxWeight,
            backpackItems = character.BackpacksNav.Select(i => new
            {
                itemName = i.Item.Name,
                itemWeight = i.Item.Weight,
                amount = i.Amount
            }).ToList(),
            titles = character.Character_TitlesNav.Select(t => new
            {
                title = t.Title.Name,
                acquiredAt = t.AcquiredAt
            }).ToList()
        };

        return res;
    }

    public async Task<bool> CheckIfCharacterExistsAsync(int characterId)
    {
        return await _context.Characters.AnyAsync(c => c.Id == characterId);
    }

    public async Task<bool> CheckIfItemsExistsAsync(List<int> itemIds)
    {
        int counter = itemIds.Count;
        foreach (int itemId in itemIds)
        {
            if (!await _context.Items.AnyAsync(i => i.Id == itemId))
            {
                counter--;
            }
        }

        if (counter == 0)
        {
            return true;
        }

        return false;
    }

    public async Task<Characters?> CheckIfCharacterHasEnoughWeight(int characterId,
        List<int> itemIds)
    { 
        var character = await _context.Characters
            .Include(x => x.BackpacksNav)
            .ThenInclude(x => x.Item)
            .Where(x => x.Id == characterId)
            .FirstOrDefaultAsync();

        if (character == null)
        {
            throw new Exception("Sth went wrong... Character with given ID doesn't exist anymore");
        }

        int remainingWeight = character.MaxWeight - character.CurrentWeight;

        var items = await _context.Items
            .Where(i => itemIds.Contains(i.Id))
            .ToListAsync();


        var itemsWeight = 0;
        foreach (var x in itemIds)
        {
            itemsWeight += items.Where(z => z.Id == x).Select(y => y.Weight).FirstOrDefault();
        }

        if (itemsWeight > remainingWeight)
        {
            return null;
        }
        return character;
    }

    public async Task<bool> AddItemsAndUpdateWeightAsync(Characters character, List<int> itemIds)
    {
        var items = await _context.Items
            .Where(i => itemIds.Contains(i.Id))
            .ToListAsync(); 
        
         foreach (var x in itemIds)
         {
             var existingBackpack = character.BackpacksNav.FirstOrDefault(b => b.ItemId == x);
        
             if (existingBackpack != null)
             {
                 // if backpack with this item exists then increment amount
                 existingBackpack.Amount += 1;
        
                 character.CurrentWeight += items.Where(z => z.Id == x).Select(y => y.Weight).FirstOrDefault();
             }
             else
             {
                 // else create new backpack with amount 1
                 var newBackpack = new Backpacks
                 {
                     CharacterId = character.Id,
                     ItemId = x,
                     Amount = 1
                 };
                 _context.Backpacks.Add(newBackpack);
        
                 character.CurrentWeight += items.Where(z => z.Id == x).Select(y => y.Weight).FirstOrDefault();
             }
        }

         var c = await _context.SaveChangesAsync();

         return true;
    }

    public async Task<List<BackpacksResponse>?> GetUpdatedBackpackAsync(int characterId)
    {
        List<BackpacksResponse> response = new List<BackpacksResponse>();

        foreach (var bp in await _context.Backpacks.Where(x => x.CharacterId == characterId).ToListAsync())
        {
            var newBp = new BackpacksResponse
            {
                Amount = bp.Amount,
                ItemId = bp.ItemId,
                CharacterId = bp.CharacterId
            };
            response.Add(newBp);
        }

        return response;
    }
}