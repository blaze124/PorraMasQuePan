namespace Domain.Entities
{
    public class Contestant
    {
        public Guid ContestantId { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Championship> Championships { get; set; } = new();
    }
}
