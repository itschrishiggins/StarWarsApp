using Microsoft.AspNetCore.Mvc;
using StarWarsApp_API.Services;

[ApiController] 
[Route("[controller]")] // Set route for the API, uses controller's name
public class StarWarsController : ControllerBase
{
    private readonly StarWarsService _starWarsService; 

    public StarWarsController(StarWarsService starWarsService) 
    {
        _starWarsService = starWarsService; 
    }

    [HttpGet] // GET method for getting characters
    public async Task<IActionResult> GetCharacters()
    {
        try
        {
            var result = await _starWarsService.GetCharacters(); // Call service to get characters
            return Ok(result); // Return OK response with the result for testing
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> GetCharacterDetail(int id)
    {
        try
        {
            var result = await _starWarsService.GetCharacterDetail(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("search")] 
    public async Task<IActionResult> Search([FromQuery] string name) // 'name' parameter from query string
    {
        try
        {
            var result = await _starWarsService.SearchCharacters(name);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
