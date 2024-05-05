﻿using PokemonReviewapp.Models;

namespace PokemonReviewapp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeID);

        bool ReviewExists(int reviewId);

        bool CreateReview(Review review);

        bool Save();
    }
}
