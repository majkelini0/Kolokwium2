using Kolos2.Models;
using Kolos2.ResponseModels;

namespace Kolos2.Services;

public interface IDbService
{
    Task<Characters?> GetCharacterByIdAsync(int id);
    
    Object GetCharacterInfoResponse(Characters character);
    
    Task<bool> CheckIfItemsExistsAsync(List<int> itemIds);
    
    Task<bool> CheckIfCharacterExistsAsync(int characterId);
    
    Task<Characters?> CheckIfCharacterHasEnoughWeight(int characterId, List<int> itemIds);
    
    Task<bool> AddItemsAndUpdateWeightAsync(Characters character, List<int> itemIds);
    Task<List<BackpacksResponse>?> GetUpdatedBackpackAsync(int characterId);
}