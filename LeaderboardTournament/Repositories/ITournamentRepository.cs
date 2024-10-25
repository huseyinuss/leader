public interface ITournamentRepository
{
    Task<Tournament> CreateTournamentAsync();
    Task<List<User>> GetTournamentParticipantsAsync(string tournamentId);
}