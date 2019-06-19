using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Empleados.Controllers;
using Proyecto_Empleados.Models.DataTransferObjects;

namespace Proyecto_Empleados.Views
{
    public partial class frmCapturarEmpleado : Form
    {
        public Empleado EmpleadoTemp { get; set; }
        EmpleadoController _controller;

        private bool EsNuevoRegistro = false;
        

        //Constructor 
        public frmCapturarEmpleado(frmListado _parent, Empleado _empleado = null) {
            InitializeComponent();
            _controller = new EmpleadoController(_parent, this);
            if (_empleado == null) {
                //Si no se incluye un objeto Empleado en los argumentos del constructor,
                //significa que es un registro de empleado nuevo 
                EmpleadoTemp = new Empleado();
                EsNuevoRegistro = true;           
            } else {
                //Si se envía uno, significa que es una edición de empleado existente. Se procede
                //a llenar el formulario con los datos del objeto Empleado recibido en los argumentos del constructor
                EsNuevoRegistro = false;              
                EmpleadoTemp = _empleado;
                txtNombre.Text = EmpleadoTemp.Nombre;
                txtApPaterno.Text = EmpleadoTemp.ApPaterno;
                txtApMaterno.Text = EmpleadoTemp.ApMaterno;
                dtpFecNac.Value = EmpleadoTemp.FecNac;
                cboDepartamento.SelectedValue = EmpleadoTemp.Departamento;
                txtSueldo.Text = EmpleadoTemp.Sueldo.ToString("0.00");
            }            
        }

        private void GuardarEmpleado() {
            EmpleadoTemp.Nombre = txtNombre.Text;
            EmpleadoTemp.ApPaterno = txtApPaterno.Text;
            EmpleadoTemp.ApMaterno = txtApMaterno.Text;
            EmpleadoTemp.FecNac = dtpFecNac.Value;
            EmpleadoTemp.Departamento = (int)cboDepartamento.SelectedValue;
            Decimal sueldo;
            Decimal.TryParse(txtSueldo.Text, out sueldo);
            EmpleadoTemp.Sueldo = sueldo;
            _controller.GuardarEmpleado(this, null, EmpleadoTemp, EsNuevoRegistro);
        }
        private bool ValidarCamposRequeridos(ErrorProvider err, TextBox txt) {
            if (txt.Text.Length > 0) {
                //Si los campos de texto no están vacíos, no se contabiliza el error.
            
                err.SetError(txt, "");
                return false;
            } else {
                //Si uno o más campos de texto están vacíos, se anula el envío de los datos del formulario.
                err.SetError(txt, "Algunos campos requeridos no están llenos. Revisalos e intenta de nuevo");
                return true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            // Validar los campos
            ValidarCamposRequeridos(errorProvider, txtNombre);
            ValidarCamposRequeridos(errorProvider, txtApPaterno);
            ValidarCamposRequeridos(errorProvider, txtApMaterno);
            ValidarCamposRequeridos(errorProvider, txtSueldo);

            // Revisar cada control para ver si tiene errores asignados
            foreach (Control ctl in Controls) {
                if (errorProvider.GetError(ctl) != "") {

                    MessageBox.Show(errorProvider.GetError(ctl));
                    return;
                }
            }
            GuardarEmpleado();
            this.Close();           
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
