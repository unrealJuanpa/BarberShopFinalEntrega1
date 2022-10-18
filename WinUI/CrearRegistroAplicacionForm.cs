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
    public partial class CrearRegistroAplicacionForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();

        public CrearRegistroAplicacionForm()
        {
            InitializeComponent();
        }

        private void CrearRegistroAplicacionForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            dateTimePicker1.Value = DateTime.Now;

            comboBox1.DataSource = logica.ListarTratamientos();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.Refresh();

            comboBox2.DataSource = logica.ListarClientes();
            comboBox2.DisplayMember = "NombreCliente";
            comboBox2.Refresh();

            comboBox3.DataSource = logica.listarEmpleados();
            comboBox3.DisplayMember = "CUI";
            comboBox3.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        void refreshgrid()
        {
            dataGridView1.DataSource = logica.ListarRegistroAplicacion();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int trat = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                int clien = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox2, 0);
                string cui = (string)programUtils.getFieldOfComboBoxSelectedItem(comboBox3, 0);
                logica.InsertRegistroAplicacion(dateTimePicker1.Value, Convert.ToDouble(textBox1.Text), trat, clien, cui);

                textBox1.Text = "";
                refreshgrid();
            }
            catch
            {
                messageManager.ShowError("Ingrese datos validos!");
            }
        }
    }
}
