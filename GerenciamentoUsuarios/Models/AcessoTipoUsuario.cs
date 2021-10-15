using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.Models
{

    [Table("AcessoTipoUsuario")]
    public class AcessoTipoUsuario
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Funcionalidade disponível")]
        [Column("NomeFuncionalidade")]
        public string NomeFuncionalidade { get; set; }

        [Display(Name = "Tipo do Usuário")]
        [ForeignKey("TipoUsuario")]
        [Column(Order  =  1)]
        public int IdTipoUsuario { get; set; }

        public virtual TipoUsuario TipoUsuario { get;set;}
    }

}
