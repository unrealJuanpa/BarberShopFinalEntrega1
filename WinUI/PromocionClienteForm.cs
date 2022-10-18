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
    public partial class PromocionClienteForm : Form
    {
        ClassLogica logica = new ClassLogica();

        public PromocionClienteForm()
        {
            InitializeComponent();
        }

        private void PromocionClienteForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logica.listarPromociones();
            dataGridView1.Refresh();
        }
    }
}
