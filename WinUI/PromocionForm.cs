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
    public partial class PromocionForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();

        public PromocionForm()
        {
            InitializeComponent();
        }

        private void PromocionForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.Value = DateTime.Now;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker2.Value = DateTime.Now;

            comboBox1.DataSource = logica.ListarTratamientos();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.Refresh();

            refreshGrids();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        void refreshGrids()
        {
            dataGridView1.DataSource = logica.listarPromociones();
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)comboBox1.SelectedItem;
                int idtrat = (int)row[0];

                logica.InsertPromocion(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, idtrat);
                messageManager.ShowInfo("Promoción agregada con éxito!");
                refreshGrids();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                messageManager.ShowError("Recuerde ingresar campos válidos!");
            }
        }
    }
}
