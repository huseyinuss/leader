using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TournamentController : ControllerBase
{
    private readonly ITournamentService _tournamentService;

    public TournamentController(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTournament()
    {
        var tournament = await _tournamentService.CreateTournamentAsync();
        return Ok(tournament);
    }

    [HttpGet("{tournamentId}/participants")]
    public async Task<IActionResult> GetParticipants(string tournamentId)
    {
        var participants = await _tournamentService.GetTournamentParticipantsAsync(tournamentId);
        return Ok(participants);
    }
}