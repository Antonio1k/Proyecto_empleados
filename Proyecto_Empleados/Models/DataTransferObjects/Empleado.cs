using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Empleados.Models.DataTransferObjects
{
    public class Empleado
    {
        int _Clave_emp;
        string _Nombre;
        string _ApPaterno;
        string _ApMaterno;
        DateTime _FecNac;
        int _Departamento;
        decimal _Sueldo;

        public int Clave_emp
        {
            get { return _Clave_emp; }
            set {  _Clave_emp = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string ApPaterno
        {
            get { return _ApPaterno; }
            set {  _ApPaterno = value; }
        }

        public string ApMaterno
        {
            get { return _ApMaterno; }
            set { _ApMaterno = value; }
        }

        public DateTime FecNac
        {
            get { return _FecNac; }
            set { _FecNac = value; }
        }
        public int Departamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }

        public decimal Sueldo
        {
            get { return _Sueldo; }
            set { _Sueldo = value; }
        }




    }
}
