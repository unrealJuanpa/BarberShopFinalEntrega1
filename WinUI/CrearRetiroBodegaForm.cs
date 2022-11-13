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
    public partial class CrearRetiroBodegaForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();
        public CrearRetiroBodegaForm()
        {
            InitializeComponent();
        }
        void refreshgrid()
        {
            dataGridView1.DataSource = logica.ListarRetiroBodega();
            dataGridView1.Refresh();
        }

        private void CrearRetiroBodegaForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.Value = DateTime.Now;

            comboBox1.DataSource = logica.ListarArticulos();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.Refresh();
            refreshgrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int arti = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                logica.InsertarRetiroBodega(int.Parse(textBox1.Text), dateTimePicker1.Value, textBox3.Text, arti);

                textBox1.Text = "";
                textBox3.Text = "";
                refreshgrid();

                messageManager.ShowInfo("Retiro de Bodega creado con éxito!");
            }
            catch
            {
                messageManager.ShowError("Ingrese datos validos!");
            }
        }
    }
}
