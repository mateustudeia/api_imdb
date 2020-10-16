using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class Vote : BaseEntity<int>
    {
        public int VoteScore { get; }

        public int UserId { get; set; }
        public int MovieId { get; set; }

        #region Foreing Keys
        public virtual User User { get; }
        public virtual Movie Movie { get; }
        #endregion
        public Vote() { }

        public Vote(int movieId, int userId, int voteScote)
        {
            VoteScore = voteScote;
            UserId = userId;
            MovieId = movieId;
        }


    }
}
