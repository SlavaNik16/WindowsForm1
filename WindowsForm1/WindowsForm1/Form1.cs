using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            butOk.Enabled = false;
            NameBox.Tag = false;
            AdresBox.Tag = false;
            ProgCheck.Tag = false;
            radioButton1.Tag = false;
            radioButton2.Tag = false;
            AgeBox.Tag = false;
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string output;
            output = "Name: Введите имя! \r\n";
            output += "Adres: Введите свой адрес! \r\n";
            output += "Programmer: Поставив галочку, вы соглашаетесь на соглашение! \r\n";
            output += "Femail/Mela: Выберите пол! \r\n";
            output += "Age: Введите свой возвраст! \r\n";
            OutputBox.Text = output; 
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

            this.NameBox.BackColor = this.NameBox.Text.Length != 0 ? System.Drawing.SystemColors.Window : Color.Red;
            this.NameBox.Tag = this.NameBox.Text.Length != 0;
            TestCheck();

        }

        private void butOk_Click(object sender, EventArgs e)
        {
            string output;
            output = $"Name: {this.NameBox.Text} \r\n";
            output += $"Adres:{this.AdresBox.Text} \r\n";
            output += $"Programmer: {this.ProgCheck.Checked} \r\n";
            output += $"Sex: {(string)(this.radioButton1.Checked ? "Femail" : "Male")}! \r\n";
            output += $"Age: {this.AgeBox.Text} \r\n";
            OutputBox.Text = output;
        }

        private void TestCheck()
        {
            this.butOk.Enabled = (((bool)(NameBox.Tag)) &&
                            ((bool)(AdresBox.Tag)) &&
                            ((bool)(ProgCheck.Tag)) &&
                            (((bool)(radioButton1.Tag)) ||
                            ((bool)(radioButton2.Tag))) &&
                            ((bool)(AgeBox.Tag)));
        }

        private void AdresBox_TextChanged(object sender, EventArgs e)
        {
            
            AdresBox.BackColor = AdresBox.Text.Length != 0 ? System.Drawing.SystemColors.Window : Color.Red;
            AdresBox.Tag = AdresBox.Text.Length != 0;
            TestCheck();
        }

        private void ProgCheck_CheckedChanged(object sender, EventArgs e)
        {
          
            if (!ProgCheck.Checked)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            ProgCheck.BackColor = ProgCheck.Checked ? System.Drawing.SystemColors.Window : Color.Red;
            ProgCheck.Tag = ProgCheck.Checked;
            TestCheck();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
            radioButton1.BackColor = System.Drawing.SystemColors.Window;
            radioButton1.Tag = radioButton1.Checked;
            TestCheck();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.BackColor = System.Drawing.SystemColors.Window;
            radioButton2.Tag = radioButton2.Checked;
            TestCheck();
        }

        private void AgeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt;
            txt = (TextBox)sender;
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else
            {
                AgeBox.Tag = true;
            }
            AgeBox.BackColor = AgeBox.Text.Length != 0 ? System.Drawing.SystemColors.Window : Color.Red;
            TestCheck();
        }
    }
}
