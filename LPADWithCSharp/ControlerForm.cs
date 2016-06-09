using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPADWithCSharp
{
    public partial class ControlerForm : MetroForm
    {
        public ControlerForm()
        {
            InitializeComponent();
            LoginForm datos=new LoginForm();
        }

        public ControlerForm(String userPas)
        {
            InitializeComponent();
            LoginForm datos = new LoginForm();
            label1.Text = "Bienvenido " + userPas;
        }
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
