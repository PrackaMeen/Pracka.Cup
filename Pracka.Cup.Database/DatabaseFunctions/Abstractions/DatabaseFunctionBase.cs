namespace Pracka.Cup.Database.DatabaseFunctions.Abstractions
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class DatabaseTableFunctionBase<T>
        : IDatabaseFunction where T : class
    {
        public abstract string Name { get; }

        public abstract string InnerQuery { get; }
        public abstract string InnerQueryParameters { get; }

        public string CreateOrAlterQuery => $@"
			-- ================================================
			-- Generated function {Name} from EF Core on {DateTime.UtcNow}
			-- ================================================
			CREATE OR ALTER FUNCTION {Name}
			(	
				{InnerQueryParameters}
			)
			RETURNS TABLE 
			AS
			RETURN 
			(
                {InnerQuery}
            )";
        public string DropQuery => $"DROP FUNCTION [{Name}]";
    }
}
