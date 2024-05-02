using PokemonReviewapp.Models;

namespace PokemonReviewapp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewid);
        ICollection<Review> GetReviewsOfAPokemon(int pokeID);

        bool ReviewExists(int reviewId);

    }
}
