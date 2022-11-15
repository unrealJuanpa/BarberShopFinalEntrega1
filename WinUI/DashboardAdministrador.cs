using BLL;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class DashboardAdministrador : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();

        public DashboardAdministrador()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ContenedorRegistroAplicacionForm contenedorRegistroAplicacionForm = new ContenedorRegistroAplicacionForm();
            contenedorRegistroAplicacionForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContenedorClientesForm contenedorClientesForm = new ContenedorClientesForm();
            contenedorClientesForm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ContenedorRetiroBodegaForm contenedorRetiroBodegaForm = new ContenedorRetiroBodegaForm();
            contenedorRetiroBodegaForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InformeDeIngresosForm informeDeIngresosForm = new InformeDeIngresosForm();
            informeDeIngresosForm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            InformeDeInventarioForm informeDeInventarioForm = new InformeDeInventarioForm();
            informeDeInventarioForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InformeDePromocionesForm informeDePromocionesForm = new InformeDePromocionesForm();
            informeDePromocionesForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoTratamientoForm form = new TipoTratamientoForm();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PromocionForm form = new PromocionForm();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EmpleadosForm form = new EmpleadosForm();
            form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ProveedoresForm form = new ProveedoresForm();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ArticuloForm articuloForm = new ArticuloForm();
            articuloForm.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            RolEmpleadoForm rolEmpleadoForm = new RolEmpleadoForm();
            rolEmpleadoForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RegistroCompraForm registroCompraForm = new RegistroCompraForm();
            registroCompraForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ContenedorRetiroBodegaForm contenedorRetiroBodegaForm = new ContenedorRetiroBodegaForm();
            contenedorRetiroBodegaForm.ShowDialog();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            ScriptEngine engine = Python.CreateEngine();
            Process.Start(@"C:\Python310\python.exe", @"C:\papita.py");
        }
    }
}
