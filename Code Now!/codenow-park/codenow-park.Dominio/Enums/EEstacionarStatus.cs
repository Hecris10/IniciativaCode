using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Enums
{
    public enum EEstacionarStatus
    {
        [Description("Veículo estacionado com sucesso")]
        Sucesso,
        [Description("Estacionamento Lotado")]
        Falha_EstacionamentoLotado,
        [Description("Veículo já se encontra no Estacionamento")]
        Falha_VeiculoJaEstacionado
    }
}
