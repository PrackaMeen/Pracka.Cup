namespace Pracka.Cup.API.Endpoints
{
    using AutoMapper;
    using Pracka.Cup.API.Mappers;
    using Pracka.Cup.API.Services;
    using Pracka.Cup.API.Services.Abstractions;
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
        private readonly IMapper _mapper;
        private readonly IHistoriesService _historiesService;
        private readonly IPlayersService _playersService;
        private readonly ITeamsService _teamsService;
        public ApiFunctions()
        {
            _context = new CupContextFactory().CreateDbContext(null);
            _mapper = GlobalMapper.Activate();
            _historiesService = new HistoriesService(_context, _mapper);
            _playersService = new PlayersService(_context, _mapper);
            _teamsService = new TeamsService(_context, _mapper);
        }
    }
}
