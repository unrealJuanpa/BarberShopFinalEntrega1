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
    public partial class ArticuloForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();
        public ArticuloForm()
        {
            InitializeComponent();
        }

        void refreshGrid()
        {
            dataGridView1.DataSource = logica.ListarArticulos();
            dataGridView1.Refresh();
        }

        private void ArticuloForm_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                logica.InsertArticulo(textBox1.Text, textBox2.Text);
                messageManager.ShowInfo("Artículo agregado con éxito!");
                refreshGrid();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch
            {
                messageManager.ShowError("Recuerde ingresar datos válidos!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Actualizar")
            {
                try
                {
                    int idprov = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    textBox1.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 1);
                    textBox2.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 2);

                    button2.Text = "Salvar";
                    button3.Enabled = false;
                    button4.Enabled = false;
                    dataGridView1.Enabled = false;
                }
                catch
                {
                    messageManager.ShowError("Recuerde seleccionar datos válidos!");
                }
            }
            else
            {
                try
                {
                    int idprov = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                    logica.UpdateArticulo(textBox1.Text, textBox2.Text, idprov);

                    messageManager.ShowInfo("Ítem actualizado con éxito!");
                    refreshGrid();

                    textBox1.Text = "";
                    textBox2.Text = "";

                    button2.Text = "Actualizar";
                    button3.Enabled = true;
                    button4.Enabled = true;
                    dataGridView1.Enabled = true;
                }
                catch
                {
                    messageManager.ShowError("Recuerde ingresar datos válidos!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idprov = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                if (idprov > -1)
                {
                    if (messageManager.AskConfirmation("Desea eliminar el elemento seleccionado?"))
                    {
                        logica.EliminarArticulo(idprov);
                        messageManager.ShowInfo("Elemento eliminado con éxito!");
                        refreshGrid();
                    }
                }
            }
            catch
            {
                messageManager.ShowError("Recuerde seleccionar datos válidos!");
            }
        }
    }
}
