using PokemonReviewapp.Data;
using PokemonReviewapp.Interfaces;
using PokemonReviewapp.Models;
using System.Reflection.Metadata.Ecma335;

namespace PokemonReviewapp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly DataContext _context;  


        public PokemonRepository(DataContext context) 
        { 
            
            _context = context; 
        
        }

        public bool CreatePokemon(int ownerId, int catId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();  

            var category = _context.Categories.Where(a => a.Id == catId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner() 
            {  
             Owner = pokemonOwnerEntity,
             Pokemon = pokemon, 
            };

            _context.Add(pokemonOwner);


            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);
            _context.Add(pokemon);

            return Save();

        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
            //going to show the first entity that it actually finds 
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
           var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
            {
                
            }
        }

        public ICollection<Pokemon> GetPokemons()
        { 
            return _context.Pokemon.OrderBy(p => p.Id).ToList();  
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
