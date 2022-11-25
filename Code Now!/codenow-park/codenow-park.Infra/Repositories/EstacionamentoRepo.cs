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
    public class EstacionamentoRepo
    {
        readonly ParkContext _contexto;
        public EstacionamentoRepo([FromServices]ParkContext context)
        {
            _contexto = context;
        }
        public Estacionamento Inserir(Estacionamento estacionamento)
        {
            _contexto.Add(estacionamento);
            _contexto.SaveChanges();

            return estacionamento;
        }

        public int Contar()
        {
            return _contexto.Estacionamentos.Count();
        }

        public Estacionamento ObterPorCnpj(string cnpj)
        {
            return ObterTodos().FirstOrDefault(o => o.Cnpj == cnpj);
        }
        public IEnumerable<Estacionamento> ObterTodos()
        {
            return _contexto.Estacionamentos;
        }
    }
}
