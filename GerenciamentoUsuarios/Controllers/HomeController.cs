using GerenciamentoUsuarios.Data;
using GerenciamentoUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string QntUsuarios()
        {
            var vConnections = new Connections();
            string Connect = vConnections.ConnectString();
            string queryString = "SELECT COUNT(*) FROM AspNetUsers";
            string QntUsuarios = "";

            using (SqlConnection connection = new SqlConnection(Connect))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QntUsuarios = String.Format("{0}",reader[0]);
                    }
                }
            }

            return QntUsuarios;
        }
        public string QntTipoUsuarios()
        {
            var vConnections = new Connections();
            string Connect = vConnections.ConnectString();
            string queryString = "SELECT COUNT(*) FROM TipoUsuario";
            string QntTipoUsuarios = "";

            using (SqlConnection connection = new SqlConnection(Connect))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QntTipoUsuarios = String.Format("{0}", reader[0]);
                    }
                }
            }

            return QntTipoUsuarios;
        }
        public string QntMovimentacao()
        {
            var vConnections = new Connections();
            string Connect = vConnections.ConnectString();
            string queryString = "SELECT COUNT(*) FROM LogAuditoria";
            string QntMovimentacao = "";

            using (SqlConnection connection = new SqlConnection(Connect))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QntMovimentacao = String.Format("{0}", reader[0]);
                    }
                }
            }

            return QntMovimentacao;
        }

        public IActionResult Index()
        {

            ViewBag.QntUsuarios = QntUsuarios();
            ViewBag.QntTipoUsuarios = QntTipoUsuarios();
            ViewBag.QntMovimentacao = QntMovimentacao();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
