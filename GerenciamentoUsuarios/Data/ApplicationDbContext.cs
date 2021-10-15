using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GerenciamentoUsuarios.Models;
using Microsoft.AspNetCore.Identity;

namespace GerenciamentoUsuarios.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GerenciamentoUsuarios.Models.TipoUsuario> TipoUsuario { get; set; }
        public DbSet<GerenciamentoUsuarios.Models.AcessoTipoUsuario> AcessoTipoUsuario { get; set; }
        public DbSet<GerenciamentoUsuarios.Models.PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<IdentityUser> Usuario { get; set; }
        public DbSet<GerenciamentoUsuarios.Models.LogAuditoria> LogAuditoria { get; set; }
    }
}
