using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class MovieRepository : IRepositoryMovie
    {
        public readonly IRepository<Movie> _repository;

        public MovieRepository(IRepository<Movie> repository)
        {
            _repository = repository;
        }
        public void Save(Movie obj)
        {
            _repository.Insert(obj);
        }
        public void Vote(int movieId, int userId)
        {

        }
        public Movie GetById(int id)
        {
            return _repository.Select(id);
        }
        public IEnumerable<Movie> GetAll()
        {
            return _repository.Select();
        }
    }
}
