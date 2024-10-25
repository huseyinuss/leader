public interface ILeaderboardRepository
{
    Task<List<LeaderboardEntry>> GetGlobalLeaderboardAsync(int limit = 1000);
    Task<List<LeaderboardEntry>> GetCountryLeaderboardAsync(string countryCode, int limit = 1000);
    Task<List<LeaderboardEntry>> GetTournamentLeaderboardAsync(string tournamentId, int limit = 35);
}