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
    public partial class TratamientoClienteForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MyProgramUtils programUtils = new MyProgramUtils();
        MessageManager messageManager = new MessageManager();

        public TratamientoClienteForm()
        {
            InitializeComponent();
        }

        private void TratamientoClienteForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logica.ListarTratamientos();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Refresh();
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
                messageManager.ShowError("Debe seleccionar un elemento válido!");
            }
        }
    }
}
