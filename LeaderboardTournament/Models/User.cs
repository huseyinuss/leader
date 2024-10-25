public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public int Coins { get; set; } = 1000;
    public int Level { get; set; } = 1;
    public int TournamentScore { get; set; } = 0;
    public string Country { get; set; }
}