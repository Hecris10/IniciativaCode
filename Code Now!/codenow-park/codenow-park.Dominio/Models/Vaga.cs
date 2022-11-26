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
        public virtual Estacionamento Estacionamento { get; set; }
        [ForeignKey(nameof(VeiculoId))]
        public virtual Veiculo Veiculo { get; set; }


        public DateTime Entrada { get; set; } = DateTime.Now;
        public Nullable<DateTime> Saida { get; set; }

        //public Nullable<DateTime> TempoEstacionado { get; set; }
        public bool Ocupado { get; set; } = true;
        public double HorasEstacionado { get; set; }
        public double ValorPagar { get; set; }
        public double ValorPago { get; set; }

        public Vaga() : base()
        {
            Entrada = DateTime.Now;
            Ocupado = true;
        }

        public void CalcularSaida(DateTime saida)
        {
            this.Saida = saida;

            var diferenca = this.Saida.Value.Subtract(this.Entrada);
            double horas = diferenca.Hours;
            double minutos = diferenca.Minutes;
            this.HorasEstacionado = horas + minutos / 100;

            this.ValorPagar = this.Estacionamento.PrecoInicial;
            if (horas > 1)
                this.ValorPagar += this.Estacionamento.PrecoHora * (horas - 1);
        }
    }
}
