using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using codenow_park.Infra.Repositories;
using codenow_park.Max.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Xml;

namespace codenow_park.Max.Pages
{
    public class MovimentoPageModel : PageModel
    {
        VeiculoRepo Repo;

        public IEnumerable<Veiculo> Veiculos { get; set; }

        public MovimentoPageModel([FromServices]ParkContext context)
        {
            var estacionamento = context.Estacionamentos.FirstOrDefault();
            Repo = new VeiculoRepo(context);
        }

        public void OnGet()
        {
            Veiculos = Repo.ObterTodos(); //.ToList();
        }

        int BotaoClicado()
        {
            
            return Veiculos.Count();
        }
        public int BotaoClicado2()
        {
            
            return Veiculos.Count() + 5;
        }
        public void OnPostFuncaoClique()
        {
            Console.WriteLine("Hello");
        }
    }
}
