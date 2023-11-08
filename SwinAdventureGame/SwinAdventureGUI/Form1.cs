using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwinAdventure;

namespace SwinAdventureGUI
{
    public partial class LoginForm : Form
    {
        string name, desc;

        public LoginForm()
        {
            InitializeComponent();
        }

        public static string passingName, passingDesc;

        private void enterButton_Click(object sender, EventArgs e)
        {
            name = nameTextBox.Text;
            desc = descTextBox.Text;

            //validation of name and description - user entered something
            if(String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter name");
            }
            else if(string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Enter description");
            }
            else
            {
                //passing the name and description to the next form after being validated
                passingName = name;
                passingDesc = desc;
                Form2 GUI = new Form2();
                GUI.Show();
                this.Hide();
            }
        }
    }    
}
