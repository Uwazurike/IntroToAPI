using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreatingApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreatingApi.Controllers
{
    public class MoviesController : ApiController
    {
        List <Movies> movies = new List <Movies>
        {
            new Movies { Id = 1, Name = "Tyrant", Category = "Action", Price = 10.99M },
            new Movies { Id = 2, Name = "Rogue", Category = "Fantasy", Price = 12.99M },
            new Movies { Id = 3, Name = "Drive", Category = "Thriller", Price = 14.99M },
            new Movies { Id = 4, Name = "Strange", Category = "Horror", Price = 16.99M }
        };

        public IEnumerable<Movies> GetAllMovies()
        {
            return movies;
        }

        public IHttpActionResult GetMovies(int id)
        {
            var movie = movies.SingleOrDefault(p => p.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        public IHttpActionResult GetMovieByCategory(string cat)
        {
            var movie = movies.SingleOrDefault(p => p.Category.ToLower() == cat.ToLower());
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        public IEnumerable<Movies> GetAddMovie(int Id, string name, string category, decimal price)
        {
            Movies movie = new Movies();
            movie.Id = Id;
            movie.Name = name;
            movie.Category = category;
            movie.Price = price;
            movies.Add(movie);
            return movies;
        }
    }
}