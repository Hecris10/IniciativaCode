using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Models
{
    public class Vaga : BaseModel
    {
        public int EstacionamentoId { get; set; }
        public int VeiculoId { get; set; }


        [ForeignKey(nameof(EstacionamentoId))]
        public Estacionamento Estacionamento { get; set; }
        [ForeignKey(nameof(VeiculoId))]
        public Veiculo Veiculo { get; set; }


        public DateTime Entrada { get; set; } = DateTime.Now;
        public Nullable<DateTime> Saida { get; set; }

        public Nullable<DateTime> TempoEstacionado { get; set; }
        public bool Ocupado { get; set; } = true;

        public Vaga() : base()
        {
            Entrada = DateTime.Now;
            Ocupado = true;
        }

    }
}
