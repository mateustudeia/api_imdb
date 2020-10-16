using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IServiceVote
    {
        void RegisterVote(int movieId, int userId, int grade);

        float AverageVotes(int movieId);
    }
}
