public interface ITournamentService
{
    Task<Tournament> CreateTournamentAsync();
    Task<List<User>> GetTournamentParticipantsAsync(string tournamentId);
}