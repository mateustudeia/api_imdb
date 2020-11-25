using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.Infra.Data.Repository
{
    public class VoteRepository : IRepositoryVote
    {
        private  IRepository<VoteUserMovie,int> _repository;

        public VoteRepository(IRepository<VoteUserMovie, int> repository)
        {
            _repository = repository;
        }
        public void Register(VoteUserMovie vote)
        {
            _repository.Insert(vote);
        }

        public IEnumerable<VoteUserMovie> GetAll(int movieId) =>
            _repository.Select().Where(v => v.MovieId == movieId);

        public int AverageVotes(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
