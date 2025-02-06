using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFront
{
    public class Usuario
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("UserName")] 
        public string UserName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Imagem")]
        public string Imagem{ get; set; }

        [JsonProperty("RoleUsuario")]
        public string Role { get; set; } 

        [JsonProperty("AssinaturaNome")] 
        public string AssinaturaNome { get; set; }

        [JsonProperty("AssinaturaDesconto")]
        public decimal AssinaturaDesconto { get; set; }
    }
}
