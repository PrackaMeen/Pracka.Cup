namespace Pracka.Cup.Database.Models
{
    using System;

    public abstract class EntityModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
