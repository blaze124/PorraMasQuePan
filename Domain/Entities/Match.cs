using Domain.Enums;

namespace Domain.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public string LocalTeam { get; set; } = string.Empty;
        public string VisitorTeam { get; set; } = string.Empty;
        public MatchResult Result { get; set; }

        public int ChampionshipId { get; set; }

        public Championship Championship { get; set; } = null!;
    }
}
