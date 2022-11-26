using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Models
{
    public class Estacionamento : BaseModel
    {
        [Required]
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public double PrecoInicial { get; set; }
        public double PrecoHora { get; set; }
        public int VagasTotais { get; set; }
        public virtual IEnumerable<Vaga> Vagas { get; set; }


        public Estacionamento() : base()
        {
            this.VagasTotais = 0;
            this.Vagas = new List<Vaga>();
        }

        public Estacionamento(string nome, string cnpj, double precoInicial, double precoHora, int vagasTotais) : this()
        {
            Nome = nome;
            Cnpj = cnpj;
            PrecoInicial = precoInicial;
            PrecoHora = precoHora;
            VagasTotais = vagasTotais;
        }
    }
}
