﻿using PokemonReviewapp.Data;
using PokemonReviewapp.Interfaces;
using PokemonReviewapp.Models;

namespace PokemonReviewapp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();

        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault(); 
          
        }

        public ICollection<Owner> GetOwnerOfaPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.PokemonId == pokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();    

        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
           return _context.PokemonOwners.Where(p => p.OwnerId == ownerId).Select(p => p.Pokemon).ToList();        
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any();
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
           _context.Update(owner);
            return Save();
        }
    }
}
