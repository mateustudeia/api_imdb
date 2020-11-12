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
        public readonly IRepositoryBase<Movie> _repositoryBase;

        public MovieRepository(IRepositoryBase<Movie> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public void Save(Movie obj)
        {
            _repositoryBase.Insert(obj);
        }
        public void Vote(int movieId, int userId)
        {

        }
        public Movie GetById(int id)
        {
            return _repositoryBase.Select(id);
        }
        public IEnumerable<Movie> GetAll()
        {
            return _repositoryBase.Select();
        }
    }
}
