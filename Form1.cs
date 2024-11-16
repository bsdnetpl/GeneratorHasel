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
            comboBox1.Items.Add("256 bity = 37 znaków");
            comboBox1.Items.Add("512 bity = 73 znaki");
            comboBox1.Items.Add("1024 bity = 146 znaków");
            comboBox1.Items.Add("2048 bity = 293 znaki");
            comboBox1.Items.Add("4096 bity = 585 znaków");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            }

        private async void button1_Click(object sender, EventArgs e)
            {
            Generator gh = new Generator();

            try
                {
                string allowedTypes = checkBox3.Checked ? "numeric,upper,lower" : "all";
                int passwordLength;

                // Ustal długość hasła na podstawie opcji
                if (checkBox2.Checked)
                    {
                    passwordLength = new[] { 18, 37, 73, 146, 293, 585 }[comboBox1.SelectedIndex];
                    }
                else
                    {
                    if (!int.TryParse(textBox1.Text, out passwordLength) || passwordLength <= 0)
                        {
                        throw new ArgumentException("Długość hasła musi być liczbą większą od 0.");
                        }
                    }

                // Wygenerowanie i wyświetlenie hasła
                string password = gh.GeneratePassword(passwordLength, allowedTypes);
                MessageBox.Show(password, "Wygenerowane hasło:");

                // Zapisanie do pliku, jeśli zaznaczono opcję
                if (checkBox1.Checked)
                    {
                    gh.SaveToFile();
                    System.Diagnostics.Process.Start("Password.txt");
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show("Proszę podać poprawne dane! \n" + ex.Message, "Błąd");
                }
            }

        private void textBox2_TextChanged(object sender, EventArgs e)
            {
            MessageBox.Show($"{textBox2.Text.Length} znaków");
            }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
            comboBox1.Visible = checkBox2.Checked;
            textBox1.Visible = !checkBox2.Checked;
            }
        }
    }
