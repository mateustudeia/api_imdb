using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class VoteRepository : IRepositoryVote
    {
        private  IRepository<Vote,int> _repository;

        public VoteRepository(IRepository<Vote, int> repository)
        {
            _repository = repository;
        }
        public void Register(Vote vote)
        {
            _repository.Insert(vote);
        }

        public IEnumerable<Vote> GetAll(int movieId) =>
            _repository.Select().Where(v => v.MovieId == movieId);

        public int AverageVotes(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
