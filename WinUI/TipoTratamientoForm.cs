using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class TipoTratamientoForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        string filepath = "";

        public TipoTratamientoForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) |*.jpg; *.jpeg; *.png";
            openFileDialog1.Multiselect = false;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    pictureBox1.Image = Image.FromFile(file);
                    filepath = file + "";
                }
                catch (IOException err)
                {
                    messageManager.ShowError("Algo ha salido mal :c\n\nDescripción:\n" + err.Message);
                }
            }
        }

        void refreshgrid()
        {
            dataGridView1.DataSource = logica.ListarTratamientos();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Refresh();
        }

        private void TipoTratamientoForm_Load(object sender, EventArgs e)
        {
            refreshgrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                logica.InsertTratamiento(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), filepath);
                messageManager.ShowInfo("Tratamiento agregado con éxito!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                pictureBox1.Image = null;
                refreshgrid();
            }
            catch (Exception err)
            {
                messageManager.ShowError("Recuerde seleccionar una imágen válida y completar los campos existentes!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
