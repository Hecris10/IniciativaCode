using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Dominio.Models
{
    public abstract class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;

        public BaseModel()
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
