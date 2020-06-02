using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recommendation_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            Form1.Gender = 1;
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            Form1.Gender = 2;
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            Form1.Local = 1;
        }

        private void radioButton4_MouseClick(object sender, MouseEventArgs e)
        {
            Form1.Local = 2;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 13; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    Form1.Category += "'" + checkedListBox1.Items[i].ToString() + "',";
                }

            }
            Form1.Category = Form1.Category.Substring(0, Form1.Category.Length - 1);
            Close();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
