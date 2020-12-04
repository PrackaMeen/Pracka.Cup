namespace Pracka.Cup.API.Mappers
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    internal class HistoryProfile : Profile
    {
        public HistoryProfile()
        {
            CreateMap<HistoryModel, HistoryDto>();
            CreateMap<CreateHistoryDto, HistoryModel>();
        }
    }
}
