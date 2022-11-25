using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Enums
{
    public enum ERetirarStatus
    {
        Sucesso,
        Falha_PagamentoNaoEfetuado,
        Falha_VeiculoNaoLocalizado,
        Falha_VeiculoJaRetirado,
        Falha_HoraSaidaAnteriorEntrada,
        PagamentoEfetuado,
        Falha_PrecoNaoCalculado
    }
}
