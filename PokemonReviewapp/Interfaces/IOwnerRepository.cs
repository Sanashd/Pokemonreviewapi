using PokemonReviewapp.Models;

namespace PokemonReviewapp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners(); 

        Owner GetOwner(int ownerId);    

        ICollection<Owner> GetOwnerOfaPokemon(int pokeId);

        ICollection<Pokemon> GetPokemonByOwner(int ownerId);

        bool OwnerExists(int ownerId);  
    }
}
