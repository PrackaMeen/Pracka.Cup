namespace Pracka.Cup.Database.Models
{
    using System;

    public abstract class EntityModel
    {
        public int Id { get; set; }
        public DateTime CreatedUTC { get; set; }
        public DateTime ModifiedUTC { get; set; }
    }
}
