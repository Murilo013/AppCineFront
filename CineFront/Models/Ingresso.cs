using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CineFront.Models
{
    public class Ingresso
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("UsuarioId")]
        public int UsuarioId { get; set; }

        [JsonProperty("CinemaNome")]

        public string CinemaNome { get; set; }

        [JsonProperty("FilmeNome")]

        public string FilmeNome { get; set; }

        [JsonProperty("FilmeData")]
        public string FilmeData { get; set; }

        [JsonProperty("Assentos")]
        public string Assentos { get; set; }

        [JsonProperty("Total")]
        public decimal Total { get; set; }

        [JsonProperty("Sala")]
        public string Sala { get; set; }
    }
}
