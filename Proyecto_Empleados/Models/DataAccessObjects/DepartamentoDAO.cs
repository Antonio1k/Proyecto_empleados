using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proyecto_Empleados.Models.DataTransferObjects;
using System.Data;

namespace Proyecto_Empleados.Models.DataAccessObjects
{
    class DepartamentoDAO:Database
    {
        SqlCommand _cmd = new SqlCommand();
        SqlDataReader _dataReader;

        public List<Departamento> getData() {
            _cmd.Connection = Conexion;
            _cmd.CommandText = "SELECT * FROM [dbo].[Departamentos]";
            _cmd.CommandType = CommandType.Text;
            Conexion.Open();
            _dataReader = _cmd.ExecuteReader();

            List<Departamento> _lista = new List<Departamento>();
            while (_dataReader.Read()) {
                _lista.Add(new Departamento {
                    Puesto = _dataReader.GetInt32(0),
                    Descripcion = _dataReader.GetString(1)
                });
            }
            _dataReader.Close();
            Conexion.Close();
            return _lista;
        }
    }
}
