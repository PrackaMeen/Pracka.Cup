namespace Pracka.Cup.Database.Models
{
    using System.Collections.Generic;

    public class PlayerModel : EntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public TeamModel SelectedTeam { get; set; }
        public ICollection<HistoryModel> GameHistories { get; set; }
        public ICollection<TeamModel> Teams { get; set; }
    }
}
