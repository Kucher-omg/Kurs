using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            newform.Show();
            Program.f2.label1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 newform = new Form3();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 newform = new Form4();
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 newform = new Form5();
            newform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 newform = new Form6();
            newform.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form7 newform = new Form7();
            newform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 newform = new Form8();
            newform.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form9 newform = new Form9();
            newform.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
