﻿using AutoMapper;
using PokemonReviewapp.Data;
using PokemonReviewapp.Interfaces;
using PokemonReviewapp.Models;

namespace PokemonReviewapp.Repository
{
    public class ReviewRepository : IReviewRepository

        
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateReview(Review review)
        {
            _context.Add(review);   
            return Save();  

        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeID)
        {
            return _context.Reviews.Where(r =>r.Pokemon.Id == pokeID).ToList(); 
        }

        public bool ReviewExists(int reviewId)
        {
           return _context.Reviews.Any(r => r.Id == reviewId);      
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); 
            return saved > 0 ? true : false;
           
        }
    }
}
