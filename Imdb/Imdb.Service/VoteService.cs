using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Service.Exceptions;
using System.Linq;

namespace Imdb.Service
{
    public class VoteService : IServiceVote
    {
        private readonly IRepositoryVote _repositoryVote;

        private readonly IRepositoryUser _repositoryUser;

        private readonly IRepositoryMovie _repositoryMovie;

        public VoteService(IRepositoryVote repositoryVote, IRepositoryUser repositoryUser, IRepositoryMovie repositoryMovie)
        {
            _repositoryVote = repositoryVote;
            _repositoryUser = repositoryUser;
            _repositoryMovie = repositoryMovie;

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
            if((_repositoryUser.GetById(userId) != null) && (_repositoryMovie.GetById(movieId)) != null)
            {
                var vote = new Vote(movieId, userId, grade);
                _repositoryVote.Register(vote);

            }

            throw new InvalidVoteException(ServicesConstants.ERR_GENERIC_REGISTER_VOTE);
        }
    }
}
