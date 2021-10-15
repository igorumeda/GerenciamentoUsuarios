using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.Models
{

    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Tipo do Usuario")]
        [Column("NomeTipoUsuario")]
        public string NomeTipoUsuario { get; set; }
    }

}
