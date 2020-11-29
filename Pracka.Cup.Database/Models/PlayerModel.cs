namespace Pracka.Cup.API.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public TeamModel SelectedTeam { get; set; }
    }
}
