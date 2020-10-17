using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Models
{
    public class AdministratorModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Education { get; set; }
        public string Profession { get; set; }
        public bool IsDisabled { get; set; }

        public AdministratorModel() { }

        public AdministratorModel(Administrator admin)
        {
            UserId = admin.UserId;
            Education = admin.Education;
            Profession = admin.Profession;
        }
    }
}
