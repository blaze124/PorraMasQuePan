using Domain.Enums;

namespace Domain.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public int MatchId { get; set; }
        public Guid ContestantId { get; set; }
        public MatchResult FinalResult { get; set; }

        public Contestant Contestant { get; set; } = null!;
        public Match Match { get; set; } = null!;
    }
}
