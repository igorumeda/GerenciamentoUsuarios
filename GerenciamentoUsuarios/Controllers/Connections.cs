using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.Controllers
{
    public class Connections
    {

        public string ConnectString()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "CASA\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "igor01sql";
            builder.InitialCatalog = "GerenciamentoUsuarios";
            string Result = builder.ConnectionString;

            return Result;

        }

    }
}
