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
            CreateMap<Review, ReviewDto>(); 
            CreateMap<Reviewer, ReviewerDto>(); 
            CreateMap<Owner, OwnerDto>();   
          
        }
    }
}
