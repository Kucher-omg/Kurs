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
    public partial class Form6 : Form
    {
        int rawsAmount;
        int colomsAmount;
        double multiplier;
        public Form6()
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
                Form6 newform = new Form6();
                newform.Show();
            }
            else this.Close();

        }

        static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
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

        public static double Rank(double[,] matrix)
        {
            int rang = 0;
            int q = 1;

            while (q <= MinValue(matrix.GetLength(0), matrix.GetLength(1)))
            {
                double[,] matbv = new double[q, q];
                for (int i = 0; i < (matrix.GetLength(0) - (q - 1)); i++)
                {
                    for (int j = 0; j < (matrix.GetLength(1) - (q - 1)); j++)
                    {
                        for (int k = 0; k < q; k++)
                        {
                            for (int c = 0; c < q; c++)
                            {
                                matbv[k, c] = matrix[i + k, j + c];
                            }
                        }

                        if (DetRec(matbv) != 0)
                        {

                            rang = q;
                        }
                    }
                }
                q++;
            }

            return rang;
        }
        private static int MinValue(int a, int b)
        {
            if (a >= b)
                return b;
            else
                return a;
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null || this.textBox1.Text == String.Empty)
            {
                validateUserEntry();
            }
            
            else
            {
                rawsAmount = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                
                multiplier = Convert.ToDouble(textBox1.Text.ToString());
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
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, Text = "0", TextAlign = HorizontalAlignment.Center });

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] array1 = new double[rawsAmount, rawsAmount];

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < rawsAmount; j++)
                {
                    array1[i, j] = int.Parse(flowLayoutPanel1.Controls[i].Controls[j].Text);
                    // Console.Write($"{array1[i, j]}");
                }
                // Console.WriteLine();
            }

            this.flowLayoutPanel2.Visible = true;
            flowLayoutPanel2.Width = (int)38 * rawsAmount;
            flowLayoutPanel2.Height = (int)32 * rawsAmount;
            this.label5.Visible = true;

            // make panel 2
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel2.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < rawsAmount; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel2.Controls[flowLayoutPanel2.Controls.Count - 1];
                    panel.Width = (int)38.5 * rawsAmount;
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, TextAlign = HorizontalAlignment.Center });

                }
            }

            double[,] result = (double[,])array1.Clone();

            for (int i = 0; i < multiplier - 1; i++)
            {
                result = Multiplication(array1, result);
                
            }

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < rawsAmount; j++)
                {
                    flowLayoutPanel2.Controls[i].Controls[j].Text = $"{result[i, j]}";

                }

            }

            

        }
    }
}
