using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string TempoDuracao { get; set; }
        public string Enredo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public string Atores { get; set; }

        public MovieModel() { }
        
        public MovieModel(Movie movie)
        {
            Id = movie.Id;
            Titulo = movie.Titulo;
            Ano = movie.Ano;
            TempoDuracao = movie.TempoDuracao.ToString();
            Enredo = movie.Enredo;
            Diretor = movie.Diretor;
            Genero = movie.Genero;
            Atores = movie.Atores;

        }
    }

}
