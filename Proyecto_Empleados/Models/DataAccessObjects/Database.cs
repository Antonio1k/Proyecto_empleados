using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Empleados.Models.DataAccessObjects
{
    public class Database
    {
        //Cadena de Conexión para servidor de Microsoft SQL Server
        protected SqlConnection Conexion = new SqlConnection(
            "workstation id = proyectoEmpleados.mssql.somee.com; packet size = 4096; user id = Antoniov94_SQLLogin_1; pwd=nfbep2yfp1;data source = proyectoEmpleados.mssql.somee.com; persist security info=False;initial catalog = proyectoEmpleados");
    }
}
