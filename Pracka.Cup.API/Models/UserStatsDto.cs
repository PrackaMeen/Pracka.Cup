namespace Pracka.Cup.API.Models
{
    public class UserStatsDto
    {
        public PlayerDto Player { get; set; }
        public TeamDto Team { get; set; }
        public int actualRank { get; set; }
        public int previousRank { get; set; }
        public int ClassicGamesWon { get; set; }
        public int OvertimeGamesWon { get; set; }
        public int ShootoutGamesWon { get; set; }
    }
}
