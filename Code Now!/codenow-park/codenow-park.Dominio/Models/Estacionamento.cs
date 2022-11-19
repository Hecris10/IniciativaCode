using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Models
{
    public class Estacionamento : BaseModel
    {
        public string Nome { get; set; }
        public decimal PrecoInicial { get; set; }
        public decimal PrecoHora { get; set; }
        public int VagasTotais { get; set; }
        public List<Vaga> Vagas { get; set; }


        public Estacionamento() : base()
        {
            this.Vagas = new List<Vaga>();
        }

        public Estacionamento(string nome, decimal precoInicial, decimal precoHora, int vagasTotais) : this()
        {
            Nome = nome;
            PrecoInicial = precoInicial;
            PrecoHora = precoHora;
            VagasTotais = vagasTotais;
        }
    }
}
