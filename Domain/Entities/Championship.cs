namespace Domain.Entities
{
    public class Championship
    {
        public int ChampionshipId { get; set;}
        public string Name { get; set; } = string.Empty;

        public List<Match> Matches { get; set; } = new();

        public List<Contestant> Contestants { get; set; } = new(); 
    }
}
