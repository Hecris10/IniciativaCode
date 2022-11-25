using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Infra.Repositories
{
    public class VeiculoRepo
    {
        //public static DateTime DataAgora { get => DateTime.Now; }
        //public DateTime DDD = DataAgora;

        readonly ParkContext _contexto;
        public VeiculoRepo([FromServices] ParkContext context)
        {
            _contexto = context;
        }

        public int Contar()
        {
            return _contexto.Veiculos.Count();
        }

        public Veiculo Inserir(Veiculo veiculo)
        {
            _contexto.Add(veiculo);
            _contexto.SaveChanges();

            return veiculo;
        }

        public Veiculo Inserir(string placa, string modelo)
        {
            var veiculo = new Veiculo(placa, modelo);
            return Inserir(veiculo);
        }

        public Veiculo ObterPorPlaca(string placa)
        {
            return ObterTodos().FirstOrDefault(o => o.Placa == placa);
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            return _contexto.Veiculos;
        }
    }
}
