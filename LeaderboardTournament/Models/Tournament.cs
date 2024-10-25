public class Tournament
{
    public string Id { get; set; }
    public List<string> Participants { get; set; } = new List<string>();
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}