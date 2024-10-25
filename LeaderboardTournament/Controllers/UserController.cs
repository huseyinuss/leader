using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] string username)
    {
        var user = await _userService.CreateUserAsync(username);
        return Ok(user);
    }

    [HttpPost("update-progress/{userId}")]
    public async Task<IActionResult> UpdateProgress(string userId, [FromBody] int levels)
    {
        var user = await _userService.UpdateProgressAsync(userId, levels);
        return Ok(user);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(string userId)
    {
        var user = await _userService.GetUserAsync(userId);
        return Ok(user);
    }
}