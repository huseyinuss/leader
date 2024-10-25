public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;

    public TournamentService(ITournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }

    public async Task<Tournament> CreateTournamentAsync()
    {
        return await _tournamentRepository.CreateTournamentAsync();
    }

    public async Task<List<User>> GetTournamentParticipantsAsync(string tournamentId)
    {
        return await _tournamentRepository.GetTournamentParticipantsAsync(tournamentId);
    }
}