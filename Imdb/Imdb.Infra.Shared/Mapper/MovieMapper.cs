using Imdb.Domain.Entities;
using Imdb.Domain.Models;

namespace Imdb.Infra.Shared.Mapper
{
    public static class MovieMapper
    {
        public static Movie ConvertToMovieEntity(this MovieModel movieModel) =>
            new Movie(movieModel);

        public static MovieModel ConvertToMovie(this Movie movie) =>
            new MovieModel(movie);
    }
}
