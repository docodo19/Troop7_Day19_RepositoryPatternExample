using System.Collections.Generic;
using Day19_RepositoryPattern.Models;

namespace Day19_RepositoryPattern.Repository
{
    public interface IMovieRepository
    {
        void CreateMovie(Movie movieToCreate);
        Movie FindMovie(int id);
        IList<Movie> ListMovies();
        void UpdateMovie(Movie movieToUpdate);
    }
}