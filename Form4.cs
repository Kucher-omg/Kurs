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
    public partial class Form4 : Form
    {
        int rawsAmount, rawsAmount2;
        int colomsAmount, colomsAmount2;
        public Form4()
        {
            InitializeComponent();
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
                Form4 newform = new Form4();
                newform.Show();
            }
            else this.Close();

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
           

        }

        static double[,] Multiplication(double[,] a, double[,] b)
        {
            
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button1.Enabled = false;

            if (this.comboBox1.SelectedItem == null || this.comboBox3.SelectedItem == null || this.comboBox2.SelectedItem == null || this.comboBox4.SelectedItem == null)
            {
                validateUserEntry();
            }
            else
            {
                rawsAmount = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                rawsAmount2 = Convert.ToInt32(comboBox3.SelectedItem.ToString());
                colomsAmount = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                colomsAmount2 = Convert.ToInt32(comboBox4.SelectedItem.ToString());

                if (colomsAmount != rawsAmount2)
                {
                    validateSizeOfMatrix2();
                }
            }
            
            

            //  Console.WriteLine($" 1 - {rawsAmount}, 2 - {colomsAmount}");

            this.label6.Visible = true;
            this.label5.Visible = true;
            this.button2.Visible = true;
            this.flowLayoutPanel1.Visible = true;
            this.flowLayoutPanel2.Visible = true;

            flowLayoutPanel1.Width = (int)37 * colomsAmount;
            flowLayoutPanel1.Height = (int)32 * rawsAmount;

            flowLayoutPanel2.Width = (int)37 * colomsAmount2;
            flowLayoutPanel2.Height = (int)32 * rawsAmount2;
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
                    box.KeyPress += TextBox_KeyPress;
                    panel.Controls.Add(box);
                }
            }
            //make panel 2
            for (int i = 0; i < rawsAmount2; i++)
            {
                flowLayoutPanel2.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < colomsAmount2; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel2.Controls[flowLayoutPanel2.Controls.Count - 1];
                    panel.Width = (int)37 * colomsAmount2;
                    TextBox box = new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center };
                    box.MouseClick += TextBox_OnFocus;
                    box.KeyPress += TextBox_KeyPress;
                    
                    panel.Controls.Add(box);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            double[,] array1 = new double[rawsAmount, colomsAmount];
            double[,] array2 = new double[rawsAmount2, colomsAmount2];

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

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {
                    array1[i, j] = double.Parse(flowLayoutPanel1.Controls[i].Controls[j].Text);
                    
                    // Console.Write($"{array1[i, j]}");
                }
                // Console.WriteLine();
            }

            
            for (int i = 0; i < rawsAmount2; i++)
            {
                for (int j = 0; j < colomsAmount2; j++)
                {
                    
                    array2[i, j] = double.Parse(flowLayoutPanel2.Controls[i].Controls[j].Text);
                    
                }
                
            }
            double[,] result = Multiplication(array1, array2);

            this.label8.Visible = true;
            label8.Location = new System.Drawing.Point(12, 196 + (27 * rawsAmount));

            flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.Location = new System.Drawing.Point(12, 226 + (27 * rawsAmount));


            flowLayoutPanel3.Width = (int)37 * colomsAmount2  ;
            flowLayoutPanel3.Height = (int)32 * rawsAmount;
            // make panel 3
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel3.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < colomsAmount2; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel3.Controls[flowLayoutPanel3.Controls.Count - 1];
                    panel.Width = (int)37 * colomsAmount2;
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center });

                }
            }
            //this.flowLayoutPanel3.Enabled = false;//ENABLE PANEL


            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount2; j++)
                {

                    flowLayoutPanel3.Controls[i].Controls[j].Text = $"{result[i, j]}";

                }

            }


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


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 newform = new Form4();
            newform.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
