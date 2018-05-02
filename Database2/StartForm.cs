using System;
using System.Windows.Forms;

namespace RDZavia
{
    public partial class StartForm : System.Windows.Forms.Form
    {
        public StartForm()
        {
            InitializeComponent();            
        }
        private void SingInButt_Click(object sender, EventArgs e)
        {
            LoginForm frm3 = new LoginForm();
            frm3.Show();
            this.Hide();
        }
        private void RegisterButt_Click(object sender, EventArgs e)
        {
            RegisterForm frm5 = new RegisterForm();
            frm5.Show();
            this.Hide();
        }
        private void SupportButt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для дальнейшего использовая программы пройдите регистрацию.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
