using PokemonReviewapp.Models;

namespace PokemonReviewapp.Interfaces
{
    public interface IReviewerRepository
    {


        ICollection<Reviewer> GetReviewers();

        Reviewer GetReviewer(int reviewerId);

        ICollection<Review> GetReviewesByReviewer(int reviewerId);

        bool ReviewerExists(int reviewerId);

    }
}
