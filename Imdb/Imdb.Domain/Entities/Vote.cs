using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class Vote : BaseEntity<int>
    {
        public int VoteNote { get; }

        public int UserId { get; set; }
        public int MovieId { get; set; }

        #region Foreing Keys
        public virtual User User { get; }
        public virtual Movie Movie { get; }
        #endregion

    }
}
