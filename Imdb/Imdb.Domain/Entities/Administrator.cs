using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class Administrator : BaseEntity<int>
    {
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDisabled { get; set; }

        #region
        public virtual User User { get; set; }
        #endregion
    }
}
