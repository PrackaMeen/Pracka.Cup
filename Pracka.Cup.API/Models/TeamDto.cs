namespace Pracka.Cup.API.Models
{
    using System;

    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public DateTime CreatedUTC { get; set; }
        public DateTime ModifiedUTC { get; set; }
    }
}
