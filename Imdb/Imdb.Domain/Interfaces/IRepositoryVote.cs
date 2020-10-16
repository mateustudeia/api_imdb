using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryVote
    {
        void Register(Vote vote);
        int AverageVotes(int movieId);
    }
}
