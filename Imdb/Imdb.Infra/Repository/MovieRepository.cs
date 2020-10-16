using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class MovieRepository : BaseRepository<Movie, int>, IRepositoryMovie
    {
        public MovieRepository(ImdbContext imdbContext) : base(imdbContext) { }
        public void Save(Movie obj)
        {
            base.Insert(obj);
        }
        public void Vote(int movieId, int userId)
        {

        }
        public Movie GetById(int id)
        {
            return Select(id);
        }
        public IEnumerable<Movie> GetAll()
        {
            return Select();
        }
    }
}
