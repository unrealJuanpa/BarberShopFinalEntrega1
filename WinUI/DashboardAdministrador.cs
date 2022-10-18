using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
