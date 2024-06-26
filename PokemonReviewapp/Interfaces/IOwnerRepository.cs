﻿using PokemonReviewapp.Models;

namespace PokemonReviewapp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners(); 

        Owner GetOwner(int ownerId);    

        ICollection<Owner> GetOwnerOfaPokemon(int pokeId);

        ICollection<Pokemon> GetPokemonByOwner(int ownerId);

        bool OwnerExists(int ownerId);

        bool Save();

        bool CreateOwner(Owner owner);
         
        bool UpdateOwner(Owner owner);  

        bool DeleteOwner(Owner owner);  


    }
}
