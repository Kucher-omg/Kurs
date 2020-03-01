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
    
    public partial class Form9 : Form
    {
        int rawsAmount;
        public Form9()
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
                Form9 newform = new Form9();
                newform.Show();
            }
            else this.Close();

        }

        public static double[,] Inverted(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            double[,] res = new double[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res[i, j] = matrix[i, j];
                }
            }

            if (n != m)
            {
                throw new Exception("Inverted matrix can`t be");
            }

            int[] row = new int[n];
            int[] col = new int[n];

            double[] temp = new double[n];
            int hold;
            int I_pivot;
            int J_pivot;
            double pivot;
            double abs_pivot;

            for (int k = 0; k < n; k++)
            {
                row[k] = k;
                col[k] = k;
            }

            for (int k = 0; k < n; k++)
            {

                pivot = res[row[k], col[k]];
                I_pivot = k;
                J_pivot = k;
                for (int i = k; i < n; i++)
                {
                    for (int j = k; j < n; j++)
                    {
                        abs_pivot = Math.Abs(pivot);
                        if (Math.Abs(res[row[i], col[j]]) > abs_pivot)
                        {
                            I_pivot = i;
                            J_pivot = j;
                            pivot = res[row[i], col[j]];
                        }
                    }
                }

                if (Math.Abs(pivot) < 1.0E-10)
                {

                    throw new Exception("!");
                }

                hold = row[k];
                row[k] = row[I_pivot];
                row[I_pivot] = hold;
                hold = col[k];
                col[k] = col[J_pivot];
                col[J_pivot] = hold;

                res[row[k], col[k]] = 1.0 / pivot;

                for (int j = 0; j < n; j++)
                {
                    if (j != k)
                    {
                        res[row[k], col[j]] = res[row[k], col[j]] * res[row[k], col[k]];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    if (k != i)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (k != j)
                            {
                                res[row[i], col[j]] = res[row[i], col[j]] - res[row[i], col[k]] * res[row[k], col[j]];
                            }
                        }
                        res[row[i], col[k]] = -res[row[i], col[k]] * res[row[k], col[k]];
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    temp[col[i]] = res[row[i], j];
                }

                for (int i = 0; i < n; i++)
                {
                    res[i, j] = temp[i];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[row[j]] = res[i, col[j]];
                }

                for (int j = 0; j < n; j++)
                {
                    res[i, j] = temp[j];
                }
            }

            return res;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null)
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
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, Text = "2", TextAlign = HorizontalAlignment.Center });

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
            flowLayoutPanel2.Width = (int)42 * rawsAmount;
            flowLayoutPanel2.Height = (int)32 * rawsAmount;
            this.label5.Visible = true;

            // make panel 2
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel2.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < rawsAmount; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel2.Controls[flowLayoutPanel2.Controls.Count - 1];
                    panel.Width = (int)42 * rawsAmount;
                    panel.Controls.Add(new TextBox { Width = 35, Height = 20, TextAlign = HorizontalAlignment.Center });

                }
            }
            double[,] result = Inverted(array1);
           // Math.Round(result[i, j], 2)

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < rawsAmount; j++)
                {
                    if (result[i, j] < 0.00001 && result[i, j] > 0)
                    {
                        result[i, j] = 0;
                    }
                    flowLayoutPanel2.Controls[i].Controls[j].Text = $"{Math.Round(result[i, j], 3)}";

                }

            }

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
