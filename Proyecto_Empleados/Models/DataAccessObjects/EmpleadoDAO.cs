using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Proyecto_Empleados.Models.DataTransferObjects;

namespace Proyecto_Empleados.Models.DataAccessObjects
{
    class EmpleadoDAO : Database {
        SqlCommand _cmd = new SqlCommand();
        SqlDataReader _dataReader;
        
        public List<Empleado> getData() {
            _cmd.Connection = Conexion;
            _cmd.CommandText = "SELECT * FROM [dbo].[Empleados]";
            _cmd.CommandType = CommandType.Text;
            Conexion.Open();
            _dataReader = _cmd.ExecuteReader();

            List<Empleado> _lista = new List<Empleado>();
            while (_dataReader.Read()) {
                _lista.Add(new Empleado {
                    Clave_emp = _dataReader.GetInt32(0),
                    Nombre = _dataReader.GetString(1),
                    ApPaterno = _dataReader.GetString(2),
                    ApMaterno = _dataReader.GetString(3),
                    FecNac = _dataReader.GetDateTime(4),
                    Departamento = _dataReader.GetInt32(5),
                    Sueldo = _dataReader.GetDecimal(6)
                });
            }
            _dataReader.Close();
            Conexion.Close();
            return _lista;
        }

        public void Insert(Empleado obj) {
            _cmd.Connection = Conexion;
            Conexion.Open();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "INSERT INTO [dbo].[Empleados] (Nombre,ApPaterno,ApMaterno,FecNac,Departamento,Sueldo) VALUES (@Nombre,@ApPaterno,@ApMaterno,@FecNac,@Dpto,@sueldo);";
            _cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = obj.Nombre;
            _cmd.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 50).Value = obj.ApPaterno;
            _cmd.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 50).Value = obj.ApMaterno;
            _cmd.Parameters.Add("@FecNac", SqlDbType.DateTime).Value = obj.FecNac;
            _cmd.Parameters.Add("@Dpto", SqlDbType.Int).Value = obj.Departamento;
            _cmd.Parameters.Add("@Sueldo", SqlDbType.Money).Value = obj.Sueldo;
            _cmd.ExecuteNonQuery();
            Conexion.Close();

        }
        public void Edit(Empleado obj) {
            _cmd.Connection = Conexion;
            Conexion.Open();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "UPDATE [dbo].[Empleados] SET [Nombre] = @Nombre, [ApPaterno] = @ApPaterno, [ApMaterno] = @ApMaterno, [FecNac] = @FecNac, [Departamento] = @Dpto, [Sueldo] = @Sueldo WHERE Clave_emp = @id;";
            _cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = obj.Nombre;
            _cmd.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 50).Value = obj.ApPaterno;
            _cmd.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 50).Value = obj.ApMaterno;
            _cmd.Parameters.Add("@FecNac", SqlDbType.DateTime).Value = obj.FecNac;
            _cmd.Parameters.Add("@Dpto", SqlDbType.Int).Value = obj.Departamento;
            _cmd.Parameters.Add("@Sueldo", SqlDbType.Money).Value = obj.Sueldo;
            _cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.Clave_emp;
            _cmd.ExecuteNonQuery();
        }
        public void Delete(Empleado obj) {
            _cmd.Connection = Conexion;
            Conexion.Open();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "DELETE FROM [dbo].[Empleados] WHERE Clave_emp = @id;";
            _cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.Clave_emp;
            _cmd.ExecuteNonQuery();
        }
    }
}