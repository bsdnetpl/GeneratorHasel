using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorHasel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            Generator gh = new Generator();
            try
            {
                MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(textBox1.Text)), "Wygenerowane hasło: ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Proszę podać poprawne dane ! \n" + ex.ToString());
            }
            if(checkBox1.Checked == true)
            {
                gh.SaveToFileAsync();
                System.Diagnostics.Process.Start("Password.txt");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show((Convert.ToString(textBox2.Text.Length+" znaków")));
        }
    }
}
