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

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Actualizar")
            {
                try
                {
                    int idprom = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                    if (idprom > -1)
                    {
                        textBox1.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 1);
                        textBox2.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 2) + "";
                        textBox3.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 3);
                        dateTimePicker1.Value = (DateTime)programUtils.getFieldOfSelectedCell(dataGridView1, 4);
                        dateTimePicker2.Value = (DateTime)programUtils.getFieldOfSelectedCell(dataGridView1, 5);

                        for (int i = 0; i < comboBox1.Items.Count; i++)
                        {
                            int id1 = (int)programUtils.getItemOfRowComboBox(comboBox1, i, 0);
                            int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 7);

                            if (id1 == id2)
                            {
                                comboBox1.SelectedIndex = i;
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
                    int idtrat = (int)row[0];

                    int idprom = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);

                    logica.actualizarPromocion(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, idtrat, idprom);
                    messageManager.ShowInfo("Cambios guardados con éxito!");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

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
    }
}
