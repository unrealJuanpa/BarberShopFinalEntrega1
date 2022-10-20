using BLL;

namespace WinUI
{
    public partial class FormLogin : Form
    {
        ClassLogica logica = new ClassLogica();
        MessageManager messageManager = new MessageManager();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PromocionClienteForm promocionClienteForm = new PromocionClienteForm();
            promocionClienteForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TratamientoClienteForm tratamientoClienteForm = new TratamientoClienteForm();
            tratamientoClienteForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int res = logica.VerifyLogin(textBox1.Text);

                if (res == 1)
                {
                    DashboardAdministrador form = new DashboardAdministrador();
                    form.ShowDialog();
                    textBox1.Text = "";
                }
                else
                {
                    if (res == 2)
                    {
                        DashboardEmpleado form = new DashboardEmpleado();
                        form.ShowDialog();
                        textBox1.Text = "";
                    }
                }
            }
            catch (Exception err)
            {
                messageManager.ShowError("Usuario incorrecto!");
            }
        }
    }
}