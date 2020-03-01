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
            string message = "Ти деган, ти ніхуя не ввів, введеш ще раз?";
            string caption = "Пізда";
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
            if (this.comboBox1.SelectedItem == null || this.comboBox3.SelectedItem == null)
            {
                validateUserEntry();
            }
            else if (this.comboBox2.SelectedItem == null || this.comboBox4.SelectedItem == null)
            {
                validateUserEntry();
            }
            else
            {
                rawsAmount = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                rawsAmount2 = Convert.ToInt32(comboBox3.SelectedItem.ToString());
                colomsAmount = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                colomsAmount2 = Convert.ToInt32(comboBox4.SelectedItem.ToString());
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
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center });

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
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center });

                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            double[,] array1 = new double[rawsAmount, colomsAmount];
            double[,] array2 = new double[rawsAmount2, colomsAmount2];
            
            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {
                    array1[i, j] = int.Parse(flowLayoutPanel1.Controls[i].Controls[j].Text);
                    
                    // Console.Write($"{array1[i, j]}");
                }
                // Console.WriteLine();
            }

            
            for (int i = 0; i < rawsAmount2; i++)
            {
                for (int j = 0; j < colomsAmount2; j++)
                {
                    
                    array2[i, j] = int.Parse(flowLayoutPanel2.Controls[i].Controls[j].Text);
                    
                }
                
            }
            double[,] result = Multiplication(array1, array2);

            this.label8.Visible = true;
            label8.Location = new System.Drawing.Point(12, 196 + (27 * rawsAmount));

            flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.Location = new System.Drawing.Point(12, 226 + (27 * rawsAmount));


            flowLayoutPanel3.Width = (int)37 * rawsAmount ;
            flowLayoutPanel3.Height = (int)32 * colomsAmount2;
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

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount2; j++)
                {

                    flowLayoutPanel3.Controls[i].Controls[j].Text = $"{result[i, j]}";

                }

            }


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
