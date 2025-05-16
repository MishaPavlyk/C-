using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly SupabaseService _supabaseService;

    public UserController(SupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _supabaseService.GetUsersAsync();
        return Ok(users);
    }
}
