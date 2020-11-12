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
        IRepositoryBase<Vote> _repositoryBase;

        public VoteRepository(IRepositoryBase<Vote> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public void Register(Vote vote)
        {
            _repositoryBase.Insert(vote);
        }

        public IEnumerable<Vote> GetAll(int movieId) =>
            _repositoryBase.Select().Where(v => v.MovieId == movieId);

        public int AverageVotes(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
