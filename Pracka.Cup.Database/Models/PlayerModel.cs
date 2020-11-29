namespace Pracka.Cup.Database.Models
{
    using System.Collections.Generic;

    public class PlayerModel : EntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int SelectedTeamId { get; set; }
        public virtual TeamModel SelectedTeam { get; set; }
        public virtual ICollection<HistoryModel> HomeGameHistories { get; set; }
        public virtual ICollection<HistoryModel> AwayGameHistories { get; set; }
    }
}
