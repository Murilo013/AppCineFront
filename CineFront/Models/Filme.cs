using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFront
{
    public class Filme
    {
        public int Id { get; set; }
        public string FilmeNome { get; set; } = string.Empty;
        public int Duracao { get; set; }
        public int Horario { get; set; }
        public string Data { get; set; } = string.Empty;
        public string Sala { get; set; } = string.Empty;
        public int CinemaId { get; set; } // FK
    }
}


