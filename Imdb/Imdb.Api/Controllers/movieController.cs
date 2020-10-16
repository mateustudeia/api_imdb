using System;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IServiceMovie _serviceMovie;

        private readonly IServiceVote _serviceVote;

        public MovieController(IServiceMovie serviceMovie) =>
            _serviceMovie = serviceMovie;

        [HttpPost]
        public IActionResult Create([FromBody] MovieModel movieModel)
        {
            try
            {
                var movie = _serviceMovie.Insert(movieModel);

                return Created($"/api/movies/{movie?.Id}", movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("getFilter")]
        public IActionResult GetFilteredMovie([FromQuery] MovieFilterModel filter)
        {
            try
            {
                var movies = _serviceMovie.GetFilteredMovies(filter);

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{idMovie}")]
        public IActionResult GetDetailedMovie(int id)
        {
            try
            {
                var movies = _serviceMovie.GetMovieDetailedById(id);

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("registro")]
        public IActionResult RegisterVote([FromQuery]int movieId, int userId, int voteScore)
        {
            try
            {
                _serviceVote.RegisterVote(movieId, userId, voteScore);

                return Ok(ApiConstants.MSG_GENERIC_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
