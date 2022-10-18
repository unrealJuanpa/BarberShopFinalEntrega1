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
    public partial class RUDClienteForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();

        public RUDClienteForm()
        {
            InitializeComponent();
        }

        void refreshGrids()
        {
            dataGridView1.DataSource = logica.ListarClientes();
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.SelectedCells[0].RowIndex;
            int idcliente = (int)dataGridView1.Rows[idx].Cells[0].Value;

            if (idcliente > -1)
            {
                if (messageManager.AskConfirmation("Esta seguro de actualizar los datos del cliente seleccionado?"))
                {
                    logica.ActualizarCliente(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), idcliente);
                    messageManager.ShowInfo("Cliente actualizado con éxito!");
                    refreshGrids();
                }
            }
        }

        private void RUDClienteForm_Load(object sender, EventArgs e)
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
                    textBox1.Text = (string)dataGridView1.Rows[idx].Cells[1].Value;
                    textBox2.Text = (string)dataGridView1.Rows[idx].Cells[2].Value;
                    textBox3.Text = dataGridView1.Rows[idx].Cells[3].Value + "";
                }
            }
            catch
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.SelectedCells[0].RowIndex;
            int idcliente = (int)dataGridView1.Rows[idx].Cells[0].Value;

            if (idcliente > -1 && messageManager.AskConfirmation("Esta seguro de eliminar al cliente seleccionado?"))
            {
                logica.EliminarCliente(idcliente);
                messageManager.ShowInfo("Cliente eliminado con éxito");
                refreshGrids();
            }
        }
    }
}
