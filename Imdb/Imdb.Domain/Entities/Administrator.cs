using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class Administrator : BaseEntity<int>
    {
        public int UserId { get;}
        public DateTime CreationDate { get; }
        public string Education { get; }
        public string Profession { get; }
        public bool IsDisabled { get; private set; }


        #region Foreign Keys
        public virtual User User { get; set; }
        #endregion


        #region Constructors

        public Administrator() { }

        public Administrator( AdministratorModel admin) : base(admin.Id)
        {
            UserId = admin.UserId;
            CreationDate = DateTime.Now;
            Education = admin.Education;
            Profession = admin.Profession;
            IsDisabled = false;
        }
        #endregion


        public void DeleteAdministrator()
        {
            IsDisabled = true;
        }
    }
}
