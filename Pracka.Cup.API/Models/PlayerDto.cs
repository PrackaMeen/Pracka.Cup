namespace Pracka.Cup.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int SelectedTeamId { get; set; }
    }
}
