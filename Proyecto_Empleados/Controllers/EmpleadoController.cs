using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Empleados.Views;
using Proyecto_Empleados.Models.DataAccessObjects;
using Proyecto_Empleados.Models.DataTransferObjects;

namespace Proyecto_Empleados.Controllers
{
    class EmpleadoController
    {
        frmCapturarEmpleado viewCapturarEmpleado;
        frmListado viewEmpleados;

        public EmpleadoController(frmListado viewListar, frmCapturarEmpleado viewCapturar) {
            viewEmpleados = viewListar;
            viewCapturarEmpleado = viewCapturar;
            viewCapturarEmpleado.FormClosed += new FormClosedEventHandler(CargarEmpleados);
            
            viewCapturarEmpleado.Load += new EventHandler(CargarDepartamentos);
        }


        public EmpleadoController(frmListado view) {
            viewEmpleados = view;
            viewEmpleados.Load += new EventHandler(CargarEmpleados);
            viewEmpleados.btnNuevoEmpleado.Click += new EventHandler(CapturarNuevoEmpleado);
            viewEmpleados.btnEditarEmpleado.Click += new EventHandler ((sender, e) => EditarEmpleado(sender, e, viewEmpleados.dataGridView1.SelectedRows[0].DataBoundItem as Empleado));
            viewEmpleados.btnEliminarEmpleado.Click += new EventHandler((sender, e) => EliminarEmpleado(sender, e, viewEmpleados.dataGridView1.SelectedRows[0].DataBoundItem as Empleado));

            viewEmpleados.dataGridView1.SelectionChanged += new EventHandler(MostrarBotonesEditarEliminar);
            
        }

        public EmpleadoController(frmCapturarEmpleado view) {
            viewCapturarEmpleado = view;            
        }

        
        public void CargarEmpleados(Object sender, EventArgs e) {
            //Recarga la lista de empleados
            EmpleadoDAO db = new EmpleadoDAO(); 
            viewEmpleados.dataGridView1.DataSource = db.getData();
        }
        
        public void CargarDepartamentos(Object sender, EventArgs e) {
            //Recarga la lista de Departamentos y la adecua para su correcto funcionamiento en un ComboBox
            DepartamentoDAO db = new DepartamentoDAO();
            viewCapturarEmpleado.cboDepartamento.DisplayMember = "Descripcion";
            viewCapturarEmpleado.cboDepartamento.ValueMember = "Puesto";
            viewCapturarEmpleado.cboDepartamento.DataSource = db.getData();
        }


        public void MostrarBotonesEditarEliminar(Object sender, EventArgs e) {
            viewEmpleados.btnEditarEmpleado.Enabled = true;
            viewEmpleados.btnEliminarEmpleado.Enabled = true;
        }

        public void CapturarNuevoEmpleado(Object sender, EventArgs e) {
            
            viewCapturarEmpleado = new frmCapturarEmpleado(this.viewEmpleados);
            viewCapturarEmpleado.Show();            
        }

        public void EditarEmpleado(Object sender, EventArgs e, Empleado _e) {
            viewCapturarEmpleado = new frmCapturarEmpleado(this.viewEmpleados, _e);
            viewCapturarEmpleado.Show();
        }

        public void GuardarEmpleado(Object sender, EventArgs e, Empleado _e, bool esNuevoRegistro) {
            EmpleadoDAO db = new EmpleadoDAO();
            Empleado _empleado = viewCapturarEmpleado.EmpleadoTemp;
            if (esNuevoRegistro) {
                db.Insert(_empleado);
            } else {
                db.Edit(_empleado);
            }

            CargarEmpleados(this, e);
        }

        public void EliminarEmpleado(Object sender, EventArgs e, Empleado _e) {
            EmpleadoDAO db = new EmpleadoDAO();
            string msg = $"¿Está seguro que desea eliminar al empleado '{_e.ApPaterno} {_e.ApMaterno} {_e.Nombre}'?";
            const string titulo = "Confirmar Acción";
            var result = MessageBox.Show(msg, titulo,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                db.Delete(_e);
                CargarEmpleados(this, e);
            }
        }
    }
}
