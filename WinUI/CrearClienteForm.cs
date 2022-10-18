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
    public partial class CrearClienteForm : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();

        public CrearClienteForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                logica.InsertCliente(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                messageManager.ShowInfo("Cliente agregado con éxito!");
                this.Dispose();
            }
            catch (Exception ex)
            {
                messageManager.ShowError("Algo ha salido mal :c\n\nDetalles:\n" + ex.Message);
            }
        }
    }
}
