using Day19_RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day19_RepositoryPattern.Repository
{
    public class SuperAwesome : IMovieRepository
    {
        public void CreateMovie(Movie movieToCreate)
        {
            throw new NotImplementedException();
        }

        public Movie FindMovie(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Movie> ListMovies()
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            throw new NotImplementedException();
        }
    }

    public class MovieRepository : IMovieRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns></returns>
        public IList<Movie> ListMovies()
        {
            return _db.Movies.ToList();
        }

        /// <summary>
        /// Returns a single movie
        /// </summary>
        /// <param name="id">Primary key for the movie</param>
        /// <returns></returns>
        public Movie FindMovie(int id)
        {
            return _db.Movies.Find(id);
        }

        /// <summary>
        /// Creates a movie
        /// </summary>
        /// <param name="movieToCreate"></param>
        public void CreateMovie(Movie movieToCreate)
        {
            _db.Movies.Add(movieToCreate);
            _db.SaveChanges();
        }

        /// <summary>
        /// Updates a movie
        /// </summary>
        /// <param name="movieToUpdate"></param>
        public void UpdateMovie(Movie movieToUpdate)
        {
            // Load up the original movie
            var originial = this.FindMovie(movieToUpdate.Id);
            // Update information to the original data
            originial.Title = movieToUpdate.Title;
            originial.Director = movieToUpdate.Director;
            // save changes
            _db.SaveChanges();
        }
    }
}