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
            comboBox1.Items.Add("128 bity = 18 znaków");
            comboBox1.Items.Add("256 bity = 37 znaków"); // Zaokrąglono z 36.57
            comboBox1.Items.Add("512 bity = 73 znaki"); // Zaokrąglono z 73.14
            comboBox1.Items.Add("1024 bity = 146 znaków"); // Zaokrąglono z 289.14
            comboBox1.Items.Add("2048 bity = 293 znaki"); // Zaokrąglono z 292.57
            comboBox1.Items.Add("4096 bity = 585 znaków"); // Zaokrąglono z 585.14
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            Generator gh = new Generator();
            try
            {
                if (checkBox2.Checked == true)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(18)), "Wygenerowane hasło: ");
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(37)), "Wygenerowane hasło: ");
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(73)), "Wygenerowane hasło: ");
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(146)), "Wygenerowane hasło: ");
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(293)), "Wygenerowane hasło: ");
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(585)), "Wygenerowane hasło: ");
                    }
                }
                else
                {
                    MessageBox.Show(gh.GeneratePassword(Convert.ToInt32(textBox1.Text)), "Wygenerowane hasło: ");
                }
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                comboBox1.Visible = true;
                textBox1.Visible = false;
            }
            else
            {
                comboBox1.Visible = false;
                textBox1.Visible = true;
            }
        }
    }
}
