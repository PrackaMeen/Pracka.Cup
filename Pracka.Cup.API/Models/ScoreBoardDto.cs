namespace Pracka.Cup.API.Models
{
    public class ScoreBoardDto
    {
        public virtual PlayerDto Player { get; set; }
        public int PlayerId { get; set; }
        public int Wins3ptsGames { get; set; }
        public int Wins2ptsGames { get; set; }
        public int Loss1ptGames { get; set; }
        public int Loss0ptsGames { get; set; }
        public int TotalPoints { get; set; }
        public int TotalGames { get; set; }
        public int TotalGoalsScored { get; set; }
        public int TotalGoalsRecieved { get; set; }
        public double PointsPercentil { get; set; }
        public int Rank { get; set; }
    }
}
