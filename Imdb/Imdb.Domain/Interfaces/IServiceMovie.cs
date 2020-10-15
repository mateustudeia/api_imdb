using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IServiceMovie
    {
        MovieModel Insert(MovieModel movie);
        void RegisterVote(int movieId, int userId);
        IEnumerable<MovieFilterModel> GetFilteredMovies(MovieFilterModel filter);
        MovieDetailedModel GetMovieDetailedById(int id);
    }
}
