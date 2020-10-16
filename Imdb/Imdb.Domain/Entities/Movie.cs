using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace Imdb.Domain.Entities
{
    public class Movie : BaseEntity<int>
    {
        public string Titulo { get; }
        public int Ano { get; }
        public TimeSpan TempoDuracao { get; }
        public string Enredo { get; }
        public string Diretor { get; }
        public string Genero { get; }
        public string Atores { get; }

        public virtual ICollection<Vote> VoteMovie { get; set; }

        public Movie() { }

        public Movie(MovieModel movieModel) : base(movieModel.Id) 
        {
            Titulo = movieModel.Titulo;
            Ano = movieModel.Ano;
            TempoDuracao = TimeSpan.Parse(movieModel.TempoDuracao);
            Enredo = movieModel.Enredo;
            Diretor = movieModel.Diretor;
            Genero = movieModel.Genero;
            Atores = movieModel.Atores;
        }
    }


}
