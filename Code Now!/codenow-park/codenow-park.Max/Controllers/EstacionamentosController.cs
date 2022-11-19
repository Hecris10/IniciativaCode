using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codenow_park.Max.Controllers
{
    public class EstacionamentosController : Controller
    {
        private readonly ParkContext _context;

        public EstacionamentosController([FromServices]ParkContext context)
        {
            _context = context;
        }


        // GET: EstacionamentosController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estacionamentos.ToListAsync());
        }

        // GET: EstacionamentosController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estacionamentos == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Estacionamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: EstacionamentosController/Create
        public IActionResult Create()
        {
            return View(new Estacionamento());
        }

        // POST: EstacionamentosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,PrecoInicial,PrecoHora,VagasTotais")] Estacionamento estacionamento)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(estacionamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamento);
        }

        // GET: EstacionamentosController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estacionamentos == null)
            {
                return NotFound();
            }

            var estacionamento = await _context.Estacionamentos.FindAsync(id);
            if (estacionamento == null)
            {
                return NotFound();
            }
            return View(estacionamento);
        }

        // POST: EstacionamentosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,PrecoInicial,PrecoHora,VagasTotais")] Estacionamento estacionamento)
        {
            if (id != estacionamento.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacionamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionamentoExists(estacionamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamento);
        }

        // GET: EstacionamentosController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estacionamentos == null)
            {
                return NotFound();
            }

            var estacionamento = await _context.Estacionamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionamento == null)
            {
                return NotFound();
            }

            return View(estacionamento);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estacionamentos == null)
            {
                return Problem("Entity set 'ParkContext.Estacionamento'  is null.");
            }
            var estacionamento = await _context.Estacionamentos.FindAsync(id);
            if (estacionamento != null)
            {
                _context.Estacionamentos.Remove(estacionamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// POST: EstacionamentosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        private bool EstacionamentoExists(int id)
        {
            return _context.Estacionamentos.Any(e => e.Id == id);
        }
    }
}
