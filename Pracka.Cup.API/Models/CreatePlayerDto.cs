namespace Pracka.Cup.API.Models
{
    public class CreatePlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int SelectedTeamId { get; set; }
    }
}
