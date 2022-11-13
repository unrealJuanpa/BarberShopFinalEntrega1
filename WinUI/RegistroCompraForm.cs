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
    public partial class RegistroCompraForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();

        void refreshGrids()
        {
            dataGridView1.DataSource = logica.ListarRegistroCompra();
            dataGridView1.Refresh();
        }

        public RegistroCompraForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)comboBox1.SelectedItem;
                int idarti = (int)row[0];
                idarti = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);

                DataRowView row2 = (DataRowView)comboBox2.SelectedItem;
                int idprove = (int)row2[0];

                logica.InsertarRegistroCompra(dateTimePicker1.Value, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox1.Text), idarti, idprove);
                messageManager.ShowInfo("Registro de Compra agregada con éxito!");
                refreshGrids();

                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                messageManager.ShowError("Recuerde ingresar campos válidos!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Actualizar")
            {
               try
                {
                    int idprom = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                    if (idprom > -1)
                    {
                        textBox1.Text = (double)programUtils.getFieldOfSelectedCell(dataGridView1, 3)+"";
                        textBox2.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 2) + "";
                        dateTimePicker1.Value = (DateTime)programUtils.getFieldOfSelectedCell(dataGridView1, 1);

                        for (int i = 0; i < comboBox1.Items.Count; i++)
                        {
                            int id1 = (int)programUtils.getItemOfRowComboBox(comboBox1, i, 0);
                            int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 5);

                            if (id1 == id2)
                            {
                                comboBox1.SelectedIndex = i;
                                break;
                            }

                        }

                        for (int i = 0; i < comboBox2.Items.Count; i++)
                        {
                            int id1 = (int)programUtils.getItemOfRowComboBox(comboBox2, i, 0);
                            int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 6);

                            if (id1 == id2)
                            {
                                comboBox2.SelectedIndex = i;
                                break;
                            }

                        }

                        button2.Text = "Salvar";

                        dataGridView1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                    }
                    else
                    {
                        messageManager.ShowError("Debe seleccionar una promoción a editar válida!");
                    }
                }
                catch (Exception ex)
                {
                    messageManager.ShowError("Algo ha salido mal :c\n\n" + ex.Message);
                }
            }
            else
            {
                try
                {
                    DataRowView row = (DataRowView)comboBox1.SelectedItem;
                    int idarti = (int)row[0];

                    DataRowView row2 = (DataRowView)comboBox2.SelectedItem;
                    int idprove = (int)row2[0];

                    int idprom = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                    logica.ActualizarRegistroCompra(dateTimePicker1.Value, int.Parse(textBox2.Text), double.Parse(textBox1.Text), idarti, idprove, idprom);
                    messageManager.ShowInfo("Cambios guardados con éxito!");

                    textBox1.Text = "";
                    textBox2.Text = "";

                    button2.Text = "Actualizar";
                    dataGridView1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    refreshGrids();
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
                int idprom = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                if (idprom > -1)
                {
                    if (messageManager.AskConfirmation("Esta seguro que desea eliminar el elemento seleccionado?"))
                    {
                        logica.EliminarRegistroCompra(idprom);
                        messageManager.ShowInfo("Promocion eliminada con éxito!");
                        refreshGrids();
                    }
                }
            }
            catch (Exception ex)
            {
                messageManager.ShowError(ex.Message);
            }
        }

        private void RegistroCompraForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.Value = DateTime.Now;

            comboBox1.DataSource = logica.ListarArticulos();
            comboBox1.DisplayMember = "Nombre";

            comboBox2.DataSource = logica.listarProveedores();
            comboBox2.DisplayMember = "Nombre";
            comboBox2.Refresh();

            refreshGrids();
        }
    }
}
