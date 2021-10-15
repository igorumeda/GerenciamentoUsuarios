using GerenciamentoUsuarios.Data;
using GerenciamentoUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var temAcesso = await UsuarioTemAcesso(4, _context);
            if (!temAcesso)
            {
                return RedirectToAction("Index", "Home");
            }

            var usuariosComPerfis = (from user in _context.Users
                                     join PerfilUsuario in _context.PerfilUsuario on user.Id equals PerfilUsuario.UserId
                                     join TipoUsuario in _context.TipoUsuario on PerfilUsuario.IdTipoUsuario equals TipoUsuario.Id
                                     select new
                                     {
                                         UserId = user.Id,
                                         Username = user.UserName,
                                         Email = user.Email,
                                         Tipo = TipoUsuario.NomeTipoUsuario
                                     }).ToList().Select(p => new Usuario()
                                     {
                                         UserId = p.UserId,
                                         Username = p.Username,
                                         Email = p.Email,
                                         Tipo = p.Tipo
                                     });

            return View(usuariosComPerfis);
        }

    }
}