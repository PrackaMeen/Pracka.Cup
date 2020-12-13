namespace Pracka.Cup.API.Models
{
    public class HistoryWithStatsDto
    {
        public HistoryDto GameHistory { get; set; }
        public UserStatsDto WinnerStats { get; set; }
        public UserStatsDto LoserStats { get; set; }
    }
}
