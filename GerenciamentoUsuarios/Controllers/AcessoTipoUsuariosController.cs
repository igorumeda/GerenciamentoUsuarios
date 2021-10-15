using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoUsuarios.Data;
using GerenciamentoUsuarios.Models;
using Microsoft.AspNetCore.Authorization;

namespace GerenciamentoUsuarios.Controllers
{
    public class AcessoTipoUsuariosController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public AcessoTipoUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcessoTipoUsuarios
        public async Task<IActionResult> Index()
        {

            var temAcesso = await UsuarioTemAcesso(2, _context);
            if (!temAcesso)
            {
                return RedirectToAction("Index", "Home");
            }

            var applicationDbContext = _context.AcessoTipoUsuario.Include(a => a.TipoUsuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AcessoTipoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoTipoUsuario = await _context.AcessoTipoUsuario
                .Include(a => a.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoTipoUsuario == null)
            {
                return NotFound();
            }

            return View(acessoTipoUsuario);
        }

        // GET: AcessoTipoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuario, "Id", "NomeTipoUsuario");
            return View();
        }

        // POST: AcessoTipoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFuncionalidade,IdTipoUsuario")] AcessoTipoUsuario acessoTipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessoTipoUsuario);
                _context.LogAuditoria.Add(new LogAuditoria
                {
                    Descricao = "Criação de Acesso ao Tipo de Usuário",
                    Usuario = User.Identity.Name,
                    DataHora = DateTime.Now
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuario, "Id", "NomeTipoUsuario", acessoTipoUsuario.IdTipoUsuario);
            return View(acessoTipoUsuario);
        }

        // GET: AcessoTipoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoTipoUsuario = await _context.AcessoTipoUsuario.FindAsync(id);
            if (acessoTipoUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuario, "Id", "NomeTipoUsuario", acessoTipoUsuario.IdTipoUsuario);
            return View(acessoTipoUsuario);
        }

        // POST: AcessoTipoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFuncionalidade,IdTipoUsuario")] AcessoTipoUsuario acessoTipoUsuario)
        {
            if (id != acessoTipoUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessoTipoUsuario);
                    _context.LogAuditoria.Add(new LogAuditoria
                    {
                        Descricao = "Edição de Acesso ao Tipo de Usuário",
                        Usuario = User.Identity.Name,
                        DataHora = DateTime.Now
                    });
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessoTipoUsuarioExists(acessoTipoUsuario.Id))
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
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuario, "Id", "NomeTipoUsuario", acessoTipoUsuario.IdTipoUsuario);
            return View(acessoTipoUsuario);
        }

        // GET: AcessoTipoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoTipoUsuario = await _context.AcessoTipoUsuario
                .Include(a => a.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoTipoUsuario == null)
            {
                return NotFound();
            }

            return View(acessoTipoUsuario);
        }

        // POST: AcessoTipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessoTipoUsuario = await _context.AcessoTipoUsuario.FindAsync(id);
            _context.AcessoTipoUsuario.Remove(acessoTipoUsuario);
            _context.LogAuditoria.Add(new LogAuditoria
            {
                Descricao = "Exclusão de Acesso ao Tipo de Usuário",
                Usuario = User.Identity.Name,
                DataHora = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessoTipoUsuarioExists(int id)
        {
            return _context.AcessoTipoUsuario.Any(e => e.Id == id);
        }
    }
}
