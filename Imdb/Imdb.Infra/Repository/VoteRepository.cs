using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class VoteRepository : BaseRepository<Vote, int>, IRepositoryVote
    {
        public VoteRepository(ImdbContext imdbContext) : base(imdbContext) { }
        public void Register(Vote vote)
        {
            base.Insert(vote);
        }

        public IEnumerable<Vote> GetAll(int movieId) =>
            base.Select().Where(v => v.MovieId == movieId);

        public int AverageVotes(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
