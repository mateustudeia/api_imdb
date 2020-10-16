using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Imdb.Service.Exceptions;
using Infra.Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.Service
{
    public class MovieService : IServiceMovie
    {
        private readonly IRepositoryMovie _repositoryMovie;

        private readonly IRepositoryVote _repositoryVote;

        public MovieService(IRepositoryMovie repositoryMovie)
        {
            _repositoryMovie = repositoryMovie;
        }
        public MovieModel Insert(MovieModel movieModel)
        {
            var movie = movieModel.ConvertToMovieEntity();
            _repositoryMovie.Save(movie);
            return movie.ConvertToMovie();
        }

        public IEnumerable<MovieFilterModel> GetFilteredMovies(MovieFilterModel filter)
        {
            var movies = _repositoryMovie.GetAll();
            if (movies.Count() == 0) 
            {
                throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_MOVIE);
            }
            if(filter.Titulo != null)
            {
                movies = movies.Where(m => m.Titulo == filter.Titulo);
            }

            if (filter.Diretor != null)
            {
                movies = movies.Where(m => m.Diretor == filter.Diretor);
            }

            if (filter.Genero != null)
            {
                movies = movies.Where(m => m.Genero == filter.Genero);
            }

            if (filter.Atores != null)
            {
                movies = movies.Where(m => m.Atores == filter.Atores);
            }

            if (filter.Page > 0)
            {
                movies = movies.Skip((filter.Page - 1) * ServicesConstants.PRODUCT_ITEMS_PAGE).Take(ServicesConstants.PRODUCT_ITEMS_PAGE);
            }

            return movies.Select(m => new MovieFilterModel(m)).ToList();
        }
        public MovieDetailedModel GetMovieDetailedById(int id)
        {
            var movie = _repositoryMovie.GetById(id);
            var averageVote = _repositoryVote.AverageVotes(id);
            return movie == null ? throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_MOVIE) 
                : new MovieDetailedModel(movie, averageVote);

        }
    }
}
