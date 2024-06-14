using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId:int}")]
    public async Task<IActionResult> GetCharacterById(int characterId)
    {
        var character = await _dbService.GetCharacterByIdAsync(characterId);

        if (character == null)
        {
            return NotFound("Character with given ID doesn't exist");
        }

        var res =  _dbService.GetCharacterInfoResponse(character);
        
        return Ok(res);
    }
    
    [HttpPost("{characterId:int}/backpacks")]
    public async Task<IActionResult> AddItemToCharactersBackpack(int characterId, [FromBody] List<int> itemIds)
    {
        if (!await _dbService.CheckIfCharacterExistsAsync(characterId))
        {
            return NotFound("Character with given ID doesn't exist");
        }
        
        if (await _dbService.CheckIfItemsExistsAsync(itemIds))
        {
            return NotFound("Items with given IDs don't exist");
        }

        var character = await _dbService.CheckIfCharacterHasEnoughWeight(characterId, itemIds);
        if(character == null)
        {
            return BadRequest("Items weight exceeds character's weight");
        }

        if (! await _dbService.AddItemsAndUpdateWeightAsync(character, itemIds))
        {
            return BadRequest("Error while adding items to character's backpack");
        }

        var newBackpacks = await _dbService.GetUpdatedBackpackAsync(characterId);
        
        return Ok(newBackpacks);
    }
}