using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Models
{
    public class Veiculo : BaseModel
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public List<Vaga> Vagas { get; set; }

        public Veiculo() : base()
        {
         this.Vagas = new List<Vaga>();  
        }

        public Veiculo(string placa, string modelo) : this()
        {
            Placa = placa;
            Modelo = modelo;
        }
    }
}
