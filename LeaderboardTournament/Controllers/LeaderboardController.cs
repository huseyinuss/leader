using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly ILeaderboardService _leaderboardService;

    public LeaderboardController(ILeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpGet("global")]
    public async Task<IActionResult> GetGlobalLeaderboard()
    {
        var leaderboard = await _leaderboardService.GetGlobalLeaderboardAsync();
        return Ok(leaderboard);
    }

    [HttpGet("country/{countryCode}")]
    public async Task<IActionResult> GetCountryLeaderboard(string countryCode)
    {
        var leaderboard = await _leaderboardService.GetCountryLeaderboardAsync(countryCode);
        return Ok(leaderboard);
    }

    [HttpGet("tournament/{tournamentId}")]
    public async Task<IActionResult> GetTournamentLeaderboard(string tournamentId)
    {
        var leaderboard = await _leaderboardService.GetTournamentLeaderboardAsync(tournamentId);
        return Ok(leaderboard);
    }
}