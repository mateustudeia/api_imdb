using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Shared.Mapper
{
    public static class MovieMapper
    {
        public static Movie ConvertToMovieEntity(this MovieModel movieModel) =>
            new Movie(movieModel);

        public static MovieModel ConvertToMovie(this Movie movie) =>
            new MovieModel(movie);
    }
}
