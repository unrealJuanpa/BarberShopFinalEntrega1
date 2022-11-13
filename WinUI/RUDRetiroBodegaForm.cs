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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinUI
{
    public partial class RUDRetiroBodegaForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();

        public RUDRetiroBodegaForm()
        {
            InitializeComponent();
        }
        void refreshGrids()
        {
            dataGridView1.DataSource = logica.ListarClientes();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void RUDRetiroBodegaForm_Load(object sender, EventArgs e)
        {
            refreshGrids();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idx = dataGridView1.SelectedCells[0].RowIndex;
                int idcliente = (int)dataGridView1.Rows[idx].Cells[0].Value;

                if (idcliente > -1)
                {
                    textBox1.Text = (int)dataGridView1.Rows[idx].Cells[1].Value+"";
                    dateTimePicker1.Value = (DateTime)dataGridView1.Rows[idx].Cells[2].Value;
                    textBox3.Text = (string)dataGridView1.Rows[idx].Cells[3].Value;

                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}
