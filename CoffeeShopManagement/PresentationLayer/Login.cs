using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool UserLogin(string user, string pass)
        {
            return false;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtBoxName.Text.Trim();
            pass = txtBoxPass.Text;

            if (UserLogin(user, pass) == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string msg = "Username and password are incorrect";
                DialogResult result = MessageBox.Show();
            } 
                
        }
    }
}
