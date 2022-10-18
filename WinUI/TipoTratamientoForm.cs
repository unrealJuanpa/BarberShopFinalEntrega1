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
            int idx = dataGridView1.SelectedCells[0].RowIndex;
            
            if (button2.Text == "Actualizar")
            {
                try
                {
                    int idtrat = (int)dataGridView1.Rows[idx].Cells[0].Value;

                    textBox1.Text = (string)dataGridView1.Rows[idx].Cells[1].Value;
                    textBox2.Text = dataGridView1.Rows[idx].Cells[2].Value + "";
                    textBox3.Text = dataGridView1.Rows[idx].Cells[3].Value + "";
                    button2.Text = "Guardar cambios";
                    dataGridView1.Enabled = false;
                }
                catch (Exception ex)
                {
                    messageManager.ShowError("No ha seleccionado ningún ítem a editar!");
                }
            }
            else
            {
                try
                {

                }
                catch (Exception ex)
                {
                    messageManager.ShowError(ex.Message);
                }
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idx = dataGridView1.SelectedCells[0].RowIndex;
                byte[] imageData = (byte[])dataGridView1.Rows[idx].Cells[4].Value;

                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }
                //
                //set picture
                pictureBox1.Image = newImage;
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }
    }
}
