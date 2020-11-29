namespace Pracka.Cup.API.Endpoints
{
    using Pracka.Cup.Database;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public partial class ApiFunctions
    {
        public int GetIdFromPathPart(Regex regex, string pathPart, string toReplace)
        {
            var result = -1;

            var pathWithId = regex.Match(pathPart);
            if (pathWithId.Success)
            {
                var stringId = pathWithId.Value
                    .Replace(toReplace, String.Empty)
                    .Replace("/", String.Empty);

                int.TryParse(stringId, out result);
                return result;
            }

            return result;
        }

        private readonly CupContext _context;
        public ApiFunctions()
        {
            _context = new CupContextFactory().CreateDbContext(null);
        }
    }
}
