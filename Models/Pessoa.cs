using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaDiogo.Models
{
    public class Pessoa
    {
       
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public long Altura { get; set; }
    }
}
