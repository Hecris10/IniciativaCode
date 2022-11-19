using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;

namespace codenow_park.Max.Controllers
{
    public class VagasController : Controller
    {
        readonly ParkContext _context;
        int _estacionamentoId;

        public VagasController([FromServices] ParkContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                ViewBag.Error = $"Id do Estacionamento é obrigatório";
                return RedirectToAction("Index", "Home");
            }

            _estacionamentoId = id.Value;
            var _estacionamento = _context.Estacionamentos.Include(o => o.Vagas).FirstOrDefault(x => x.Id == id);
            if (_estacionamento == null)
            {
                ViewBag.Error = $"Estacionamento com Id {id} não existe";
                return RedirectToAction("Index", "Home");
            }

            var veiculos = _context.Veiculos.ToList();
            var vagas = _context.Vagas.Include(v => v.Veiculo).Where(o => o.EstacionamentoId == id).ToList();
            ViewBag.EstacionamentoId = id;
            return View(vagas);
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .Include(o => o.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Veiculos/Create
        public IActionResult Create(int? estacionamentoId)
        {
            var vaga = new Vaga(); // { EstacionamentoId = id };
            ViewBag.Estacionamento = (from x in _context.Estacionamentos
                                select new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Nome
                                }).ToList();
            ViewBag.Veiculos = (from x in _context.Veiculos
                                select new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Placa + " : " + x.Modelo
                                }).ToList();
            return View(vaga);
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstacionamentoId,VeiculoId,Entrada")] Vaga vaga)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Vagas", new { id = vaga.EstacionamentoId });
            }
            return View(vaga);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            ViewBag.Estacionamentos = (from x in _context.Estacionamentos
                                      select new SelectListItem
                                      {
                                          Value = x.Id.ToString(),
                                          Text = x.Nome
                                      }).ToList();
            ViewBag.Veiculos = (from x in _context.Veiculos
                               select new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.Placa + " : " + x.Modelo
                               }).ToList();
            return View(vaga);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstacionamentoId,VeiculoId,Entrada,Saida")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Estacionamentos"); //, vaga.EstacionamentoId);
            }
            return View(vaga);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }
            
            var est = _context.Estacionamentos.ToList();
            var vei = _context.Veiculos.ToList();
            var vaga = _context.Vagas.Include(o => o.Estacionamento)
                .FirstOrDefault(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            if (vaga.Ocupado == true)
            {
                vaga.CalcularSaida();
            }

            return View(vaga);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
 
            if (_context.Veiculos == null)
            {
                return Problem("Entity set 'ParkContext.Vagas'  is null.");
            }
            var vaga = await _context.Vagas.FindAsync(id);
            int? estacionamentoId = null;
            if (vaga != null)
            {
                estacionamentoId = vaga.EstacionamentoId;
                vaga.Ocupado = false;
                vaga.ValorPago = vaga.ValorPagar;
                _context.Vagas.Update(vaga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Vagas", new { id = estacionamentoId });
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.Id == id);
        }
    }
}