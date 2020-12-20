namespace Pracka.Cup.Database.DatabaseFunctions.Abstractions
{
    using System.Linq;

    public interface IDatabaseFunction
    {
        string Name { get; }
        string InnerQuery { get; }
        string CreateOrAlterQuery { get; }
        string DropQuery { get; }
    }
}
