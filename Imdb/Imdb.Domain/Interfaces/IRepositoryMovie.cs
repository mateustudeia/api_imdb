using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryMovie
    {
        void Save(Movie obj);
        void Vote(int movieId, int userId);
        Movie GetMovieDetailsById(int id);
        IList<Movie> GetFilteredMovie();
    }
}
