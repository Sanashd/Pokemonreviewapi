using AutoMapper;
using PokemonReviewapp.Dto;
using PokemonReviewapp.Models;

namespace PokemonReviewapp.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
          
        }
    }
}
