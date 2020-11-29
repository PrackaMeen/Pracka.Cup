namespace Pracka.Cup.Database.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class TeamModel : EntityModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<PlayerModel> PastPlayers { get; set; }
        public virtual ICollection<HistoryModel> HomeTeamHistories { get; set; }
        public virtual ICollection<HistoryModel> AwayTeamHistories { get; set; }
    }
}
