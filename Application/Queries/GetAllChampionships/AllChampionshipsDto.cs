using Application.Mapping;
using AutoMapper;
using Domain.Entities;


namespace Application.Queries.GetAllChampionships
{
    public class AllChampionshipsDto : IMapFrom<Championship>
    {
        public int ChampionshipId { get; set; }
        public string Name { get; set; } = string.Empty;

        public void Mapping(Profile profile) 
        { 
            profile.CreateMap<Championship, AllChampionshipsDto>();
        }
    }
}
