using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class Movie : BaseEntity<int>
    {
        public string Titulo { get; }
        public int Ano { get; }
        public int TempoDuracao { get; }
        public string Enredo { get; }
        public string Diretor { get; }
        public string Genero { get; }
    }
}
