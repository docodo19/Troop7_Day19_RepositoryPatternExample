using Day19_RepositoryPattern.Models;
using Day19_RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Day19_RepositoryPattern.API
{
    public class MoviesController : ApiController
    {
        //    private MovieRepository _repo = new MovieRepository();

        //    _repo can accept any instance of a class that implements the IMovieRepository
        //    private IMovieRepository _repo;

        //    When the default ctor is executed, it will also run the overloaded ctor while passing a new instance of a MovieRepository class
        //public MoviesController() : this(new MovieRepository())
        //{
        //}
        ////    The newly created instance of a MovieRepository class is not passed to parameter variable called repo
        //public MoviesController(IMovieRepository repo)
        //{
        //    //Then pass repo to private field called _repo
        //   _repo = repo;
        //}

        private IMovieRepository _repo;


        public MoviesController(IMovieRepository repo)
        {
            _repo = repo;
        }

        public IHttpActionResult Get()
        {
            return Ok(_repo.ListMovies());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_repo.FindMovie(id));
        }

        public IHttpActionResult Post(Movie movie)
        {
            // Check to see if movie object is valid
            if (ModelState.IsValid)
            {
                // If it's a new movie
                if (movie.Id == 0)
                {
                    _repo.CreateMovie(movie);
                }
                else // If it's an existing movie
                {
                    _repo.UpdateMovie(movie);

                }
                // return good status
                return Ok();
            }
            // return bad status
            return BadRequest();
        }
    }


    class Foobar
    {
        
    }
}
