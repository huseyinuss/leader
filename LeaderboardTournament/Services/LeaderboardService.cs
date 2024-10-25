public class LeaderboardService : ILeaderboardService
{
    private readonly ILeaderboardRepository _leaderboardRepository;

    public LeaderboardService(ILeaderboardRepository leaderboardRepository)
    {
        _leaderboardRepository = leaderboardRepository;
    }

    public async Task<List<LeaderboardEntry>> GetGlobalLeaderboardAsync()
    {
        return await _leaderboardRepository.GetGlobalLeaderboardAsync();
    }

    public async Task<List<LeaderboardEntry>> GetCountryLeaderboardAsync(string countryCode)
    {
        return await _leaderboardRepository.GetCountryLeaderboardAsync(countryCode);
    }

    public async Task<List<LeaderboardEntry>> GetTournamentLeaderboardAsync(string tournamentId)
    {
        return await _leaderboardRepository.GetTournamentLeaderboardAsync(tournamentId);
    }
}