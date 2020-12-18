namespace Pracka.Cup.Database.Models
{
    public class ScoreBoardModel
    {
        public int PlayerId { get; set; }
        public virtual PlayerModel Player { get; set; }
        public int TotalGames { get; set; }
        public int Loss1pt { get; set; }
        public int Wins2pts { get; set; }
        public int Wins3pts { get; set; }
    }
}
