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

namespace Proyecto_Empleados.Views
{
    public partial class frmListado : Form
    {
        public frmListado()
        {
            InitializeComponent();
            EmpleadoController c = new EmpleadoController(this);
        }

        private void frmListado_Load(object sender, EventArgs e) {
            btnEditarEmpleado.Enabled = false;
            btnEliminarEmpleado.Enabled = false;
        }
    }
}
