using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.Models
{

    [Table("LogAuditoria")]
    public class LogAuditoria
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Data")]
        [Column("DataHora")]
        public DateTime DataHora { get; set; }

        [Display(Name = "Usuário")]
        [Column("Usuario")]
        public string Usuario { get; set; }

    }

}
