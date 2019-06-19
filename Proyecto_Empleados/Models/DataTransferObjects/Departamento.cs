using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Empleados.Models.DataTransferObjects
{
    class Departamento
    {
        //Atributos
        int _Puesto;
        string _Descripcion;

        public int Puesto {
            get { return _Puesto; }
            set { _Puesto = value; }
        }

        public string Descripcion {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


    }
}
