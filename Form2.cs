using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{


    public partial class Form2 : Form
    {
        int i = 0, j = 0;
        int rawsAmount;
        int colomsAmount;
        public Form2()
        {
            Program.f2 = this;
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void validateUserEntry()
        {
            // Checks the value of the text.

            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Введені не всі дані, ввести ще раз?";
            string caption = "Помилка";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                this.Close();
                Form2 newform = new Form2();
                newform.Show();
            }
            else this.Close();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            if (this.comboBox1.SelectedItem == null || this.comboBox3.SelectedItem == null)
            {
                validateUserEntry();
            }
            else if (this.comboBox2.SelectedItem == null)
            {
                validateUserEntry();
            }
            else
            {
                rawsAmount = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                colomsAmount = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            }

            //  Console.WriteLine($" 1 - {rawsAmount}, 2 - {colomsAmount}");


            this.button2.Visible = true;
            this.flowLayoutPanel1.Visible = true;
            this.flowLayoutPanel2.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            flowLayoutPanel1.Width = (int)37 * colomsAmount;
            flowLayoutPanel1.Height = (int)32 * rawsAmount;

            flowLayoutPanel2.Width = (int)37 * colomsAmount;
            flowLayoutPanel2.Height = (int)32 * rawsAmount;
            // make panel 1
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel1.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < colomsAmount; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1];
                    panel.Width = (int)37 * colomsAmount;
                    TextBox box = new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center };
                    box.MouseClick += TextBox_OnFocus;
                    box.PreviewKeyDown += TextBox_OnFocus1;
                    box.KeyPress += TextBox_KeyPress;
                    panel.Controls.Add(box);

                }
            }

            //make panel 2
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel2.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26});

                for (int j = 0; j < colomsAmount; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel2.Controls[flowLayoutPanel2.Controls.Count - 1];
                    panel.Width = (int)37 * colomsAmount;
                    TextBox box = new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center };
                    box.MouseClick += TextBox_OnFocus;
                    box.KeyPress += TextBox_KeyPress;
                    panel.Controls.Add(box);
                }
            }


        }



        private void button2_Click(object sender, EventArgs e)
        {
            int AddOrSubtract;
            double[,] array1 = new double[rawsAmount, colomsAmount];
            double[,] array2 = new double[rawsAmount, colomsAmount];
            int k = 0, h = 0;
            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {
                    if ((flowLayoutPanel1.Controls[i].Controls[j].Text) == "")
                    {
                        k++;

                        flowLayoutPanel1.Controls[i].Controls[j].Text = "0";


                    }
                    if ((flowLayoutPanel2.Controls[i].Controls[j].Text) == "")
                    {
                        h++;

                        flowLayoutPanel2.Controls[i].Controls[j].Text = "0";


                    }
                    
                }

            }
            if (k > 0 || h > 0)
                validateSizeOfMatrix2();


            double[,] result = new double[rawsAmount, colomsAmount];

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {

                    array1[i, j] = double.Parse(flowLayoutPanel1.Controls[i].Controls[j].Text);
                    array2[i, j] = double.Parse(flowLayoutPanel2.Controls[i].Controls[j].Text);
                    // Console.Write($"{array1[i, j]}");
                }
                // Console.WriteLine();
            }

            if (comboBox3.Text == "+")
            {
                AddOrSubtract = 1;
            }
            else AddOrSubtract = 2;

            switch (AddOrSubtract)
            {
                case 1:
                    {


                        for (int i = 0; i < rawsAmount; i++)
                        {
                            for (int j = 0; j < colomsAmount; j++)
                            {
                                result[i, j] = array1[i, j] + array2[i, j];
                            }
                        }

                    }
                    break;

                case 2:
                    {

                        for (int i = 0; i < rawsAmount; i++)
                        {
                            for (int j = 0; j < colomsAmount; j++)
                            {
                                result[i, j] = array1[i, j] - array2[i, j];
                            }
                        }

                    }
                    break;
            }
            this.label8.Visible = true;
            label8.Location = new System.Drawing.Point(19, 196 + (30 * rawsAmount));

            flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.Location = new System.Drawing.Point(19, 226 + (30 * rawsAmount));


            flowLayoutPanel3.Width = (int)37 * colomsAmount;
            flowLayoutPanel3.Height = (int)32 * rawsAmount;
            // make panel 3
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel3.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < colomsAmount; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel3.Controls[flowLayoutPanel3.Controls.Count - 1];
                    panel.Width = (int)37 * colomsAmount;

                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center });

                }
            }

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {

                    flowLayoutPanel3.Controls[i].Controls[j].Text = $"{result[i, j]}";

                }

            }

        }




        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validateSizeOfMatrix2()
        {
            // Checks the value of the text.

            // Initializes the variables to pass to the MessageBox.Show method.

            string message = "Введені не всі комірки, тому вони = 0";
            string caption = "Помилка";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            //if (result == System.Windows.Forms.DialogResult.OK)
            //{
            //    // Closes the parent form.
            //    this.Close();
            //    Form4 newform = new Form4();
            //    newform.Show();
            //}


        }

        private void TextBox_OnFocus1(object sender, PreviewKeyDownEventArgs e)
        {
          //  ((TextBox)sender).AcceptsTab = ;
        }

        private void TextBox_OnFocus(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры и клавиша BackSpace и кома
            {
                e.Handled = true;
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {

            if (((TextBox)sender).Text != "")
            {
                for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
                {
                    if (((TextBox)sender).Text[i] < '0' || ((TextBox)sender).Text[i] > '9')
                    {
                        ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(i, 1);
                    }
                }
            }


        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 newform = new Form2();
            newform.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
