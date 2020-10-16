using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Models
{
    public class MovieFilterModel
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public string Atores { get; set; }
        public int Page { get; set; }

        public MovieFilterModel() { }
        public MovieFilterModel(Movie movie)
        {
            Titulo = movie.Titulo;
            Diretor = movie.Diretor;
            Genero = movie.Genero;
            Atores = movie.Atores;
        }
    }
}
