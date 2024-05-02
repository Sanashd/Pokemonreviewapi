using PokemonReviewapp.Models;

namespace PokemonReviewapp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int id);

        ICollection<Pokemon> GetPokemonByCategory(int categoryId);

        bool CategoryExists(int id);

        bool Save();

        bool CreateCategory(Category category); 

    }
}
