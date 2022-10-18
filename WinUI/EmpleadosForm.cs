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
    public partial class EmpleadosForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();

        public EmpleadosForm()
        {
            InitializeComponent();
        }

        void refreshgrid()
        {
            dataGridView1.DataSource = logica.listarEmpleados();
            dataGridView1.Refresh();
        }

        private void EmpleadosForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = logica.listarRoles();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.Refresh();

            refreshgrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int idrol = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                logica.InsertEmpleado(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), idrol);
                messageManager.ShowInfo("Ítem agregado con éxito!");
                refreshgrid();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch (Exception err)
            {
                messageManager.ShowError(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Actualizar")
            {
                try
                {
                    textBox5.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    textBox1.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 1);
                    textBox2.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 2);
                    textBox3.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 3);
                    textBox4.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 4) + "";

                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        int id1 = (int)programUtils.getItemOfRowComboBox(comboBox1, i, 0);
                        int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 6);


                        if (id1 == id2)
                        {
                            comboBox1.SelectedIndex = i;
                            break;
                        }
                    }

                    button2.Text = "Salvar";
                    button4.Enabled = false;
                    button3.Enabled = false;
                    dataGridView1.Enabled = false;
                }
                catch (Exception ex)
                {
                    messageManager.ShowError("Debe seleccionar un ítem a editar válido!");
                }
            }
            else
            {
                try
                {
                    int idrol = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                    string original_cui = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    logica.actualizarEmpleado(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), idrol,original_cui);

                    messageManager.ShowInfo("Empleado actualizado con éxito!");
                    refreshgrid();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    button2.Text = "Actualizar";
                    button4.Enabled = true;
                    button3.Enabled = true;
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
                string cuidel = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                if (messageManager.AskConfirmation("Desea eliminear el ítem seleccionado?"))
                {
                    logica.eliminarEmpleado(cuidel);
                    messageManager.ShowInfo("Empleado eliminado con éxito!");
                    refreshgrid();
                }
            }
            catch
            {
                messageManager.ShowError("Recuerde seleccionar un ítem a eliminar!");
            }
        }
    }
}
