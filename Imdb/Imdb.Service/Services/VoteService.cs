using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.Service.Services
{
    public class VoteService : IServiceVote
    {
        private readonly IRepositoryVote _repositoryVote;

        public VoteService(IRepositoryVote repositoryVote)
        {
            _repositoryVote = repositoryVote;
        }

        public float AverageVotes(int movieId)
        {
            var votes = _repositoryVote.GetAll(movieId);
            if (votes.Count() > 0)
            {
                var average = votes.Sum(v => v.VoteScore) / votes.Count();
                return average;
            }

            return 0;
        }

        public void RegisterVote(int movieId, int userId, int grade)
        {
            var vote = new Vote(movieId, userId, grade);
            _repositoryVote.Register(vote);
        }
    }
}
