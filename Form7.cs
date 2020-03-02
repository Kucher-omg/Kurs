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
    
    public partial class Form7 : Form
    {
        int rawsAmount;
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static double DetRec(double[,] matrix)
        {
            if (matrix.Length == 4)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double sign = 1, result = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                double[,] minor = GetMinor(matrix, i);
                result += sign * matrix[0, i] * DetRec(minor);
                sign = -sign;
            }
            return result;
        }

        private static double[,] GetMinor(double[,] matrix, int n)
        {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == n)
                        continue;
                    result[i - 1, col] = matrix[i, j];
                    col++;
                }
            }
            return result;
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
                Form7 newform = new Form7();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;

            if (this.comboBox1.SelectedItem == null )
            {
                validateUserEntry();
            }
            else
            {
                rawsAmount = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            }

            this.button2.Visible = true;
            this.label6.Visible = true;
            this.flowLayoutPanel1.Visible = true;

            flowLayoutPanel1.Width = (int)37 * rawsAmount;
            flowLayoutPanel1.Height = (int)32 * rawsAmount;

            // make panel 1
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel1.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < rawsAmount; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1];
                    panel.Width = (int)37 * rawsAmount;
                    TextBox box = new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center };
                    box.MouseClick += TextBox_OnFocus;
                    box.KeyPress += TextBox_KeyPress;
                    panel.Controls.Add(box);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] array1 = new double[rawsAmount, rawsAmount];

            int k = 0;
            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < rawsAmount; j++)
                {
                    if ((flowLayoutPanel1.Controls[i].Controls[j].Text) == "" )
                    {
                        k++;
                        flowLayoutPanel1.Controls[i].Controls[j].Text = "0";

                        if (k == 1)
                            validateSizeOfMatrix2();
                    }

                }

            }

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < rawsAmount; j++)
                {
                    array1[i, j] = int.Parse(flowLayoutPanel1.Controls[i].Controls[j].Text);
                    // Console.Write($"{array1[i, j]}");
                }
                // Console.WriteLine();
            }


            this.label5.Visible = true;
            label5.Location = new System.Drawing.Point(14, 150 + (30 * rawsAmount));
            double det = DetRec(array1);

            this.label5.Text = $"Визначник матриці:   {det}";

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
    }
}
