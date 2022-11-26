using codenow_park.Dominio.Enums;
using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace codenow_park.Infra.Repositories
{
    public class MovimentacaoRepo
    {
        readonly ParkContext _contexto;
        readonly Estacionamento _estacionamento;
        public MovimentacaoRepo([FromServices] ParkContext context, Estacionamento estacionamento)
        {
            _contexto = context;
            _estacionamento = estacionamento;
        }

        public EEstacionarStatus Estacionar(Veiculo veiculo)
        {
            if (_estacionamento.Vagas.Any(o => o.Veiculo == veiculo && o.Ocupado))
                return EEstacionarStatus.Falha_VeiculoJaEstacionado;

            if (_estacionamento.Vagas.Count() >= _estacionamento.VagasTotais)
                return EEstacionarStatus.Falha_EstacionamentoLotado;

            var vaga = new Vaga
            {
                Estacionamento = _estacionamento,
                Veiculo = veiculo,
                Entrada = DateTime.Now
            };
            _contexto.Add(vaga);
            _contexto.SaveChanges();
            return EEstacionarStatus.Sucesso;
        }

        public int ObterOcupacaoAtual()
        {
            return _estacionamento.Vagas.Count(p => p.Ocupado);
        }

        public ERetirarStatus CalcularEstacionamento(Vaga vaga, DateTime? horaSaida)
        {
            if (horaSaida == null)
                horaSaida = DateTime.Now;

            if (vaga == null)
                return ERetirarStatus.Falha_VeiculoNaoLocalizado;

            if (!vaga.Ocupado)
                return ERetirarStatus.Falha_VeiculoJaRetirado;

            if (horaSaida.Value < vaga.Entrada)
                return ERetirarStatus.Falha_HoraSaidaAnteriorEntrada;

            vaga.CalcularSaida(horaSaida.Value);

            return ERetirarStatus.PagamentoEfetuado;
        }
        
        public ERetirarStatus PagarEstacionamento(Vaga vaga)
        {
            if (!vaga.Ocupado)
                return ERetirarStatus.Falha_VeiculoJaRetirado;

            if (vaga.ValorPagar == 0)
                return ERetirarStatus.Falha_PrecoNaoCalculado;

            vaga.ValorPago = vaga.ValorPagar;
            _contexto.Update(vaga);
            return ERetirarStatus.PagamentoEfetuado;
        }


        public ERetirarStatus Retirar(Vaga vaga)
        {
            if (!vaga.Ocupado)
                return ERetirarStatus.Falha_VeiculoJaRetirado;
            
            if (vaga.ValorPagar == 0)
                return ERetirarStatus.Falha_PrecoNaoCalculado;
            
            if (vaga.ValorPago != vaga.ValorPagar)
                return ERetirarStatus.Falha_PagamentoNaoEfetuado;

            vaga.Ocupado = false;
            _contexto.Update(vaga);
            _contexto.SaveChanges();

            return ERetirarStatus.Sucesso;
        }

        public IEnumerable<Vaga> ObterVagas()
        {
            return _contexto.Vagas;
        }
    }
}
