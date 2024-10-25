public interface ILeaderboardService
{
    Task<List<LeaderboardEntry>> GetGlobalLeaderboardAsync();
    Task<List<LeaderboardEntry>> GetCountryLeaderboardAsync(string countryCode);
    Task<List<LeaderboardEntry>> GetTournamentLeaderboardAsync(string tournamentId);
}