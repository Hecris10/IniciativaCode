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
        public double PrecoInicial { get; set; }
        public double PrecoHora { get; set; }
        public int VagasTotais { get; set; }
        public virtual IEnumerable<Vaga> Vagas { get; set; }


        public Estacionamento() : base()
        {
            this.VagasTotais = 0;
            this.Vagas = new List<Vaga>();
        }

        public Estacionamento(string nome, double precoInicial, double precoHora, int vagasTotais) : this()
        {
            Nome = nome;
            PrecoInicial = precoInicial;
            PrecoHora = precoHora;
            VagasTotais = vagasTotais;
        }
    }
}
