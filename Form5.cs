﻿using System;
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
    public partial class Form5 : Form
    {
        int rawsAmount;
        int colomsAmount;
        double multiplier;
        public Form5()
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
                Form5 newform = new Form5();
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
            //if (result == System.Windows.Forms.DialogResult.OK)
            //{
            //    // Closes the parent form.
            //    this.Close();
            //    Form4 newform = new Form4();
            //    newform.Show();
            //}
            

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
            else if (this.comboBox2.SelectedItem == null)
            {
                validateUserEntry();
            }
            else
            {
                rawsAmount = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                colomsAmount = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                multiplier = Convert.ToDouble(textBox1.Text.ToString());
            }

            this.button2.Visible = true;
            this.label6.Visible = true;
            this.flowLayoutPanel1.Visible = true;
            this.textBox1.Visible = true;
            this.label7.Visible = true;

            textBox1.MouseClick += TextBox_OnFocus;
            textBox1.KeyPress += TextBox_KeyPress;

            flowLayoutPanel1.Width = (int)37 * colomsAmount;
            flowLayoutPanel1.Height = (int)32 * rawsAmount;

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



        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] array1 = new double[rawsAmount, colomsAmount];
            int k = 0;
            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {
                    if ((flowLayoutPanel1.Controls[i].Controls[j].Text) == "")
                    {
                        k++;
                        
                        flowLayoutPanel1.Controls[i].Controls[j].Text = "0";
                        
                        if (k == 1)
                            validateSizeOfMatrix2();
                    }
                    
                }
                
            }

            if (this.textBox1.Text == String.Empty)
            {
                validateUserEntry();
            }
            else
            {
                multiplier = Convert.ToDouble(textBox1.Text.ToString());


                

                for (int i = 0; i < rawsAmount; i++)
                {
                    for (int j = 0; j < colomsAmount; j++)
                    {
                        array1[i, j] = double.Parse(flowLayoutPanel1.Controls[i].Controls[j].Text);
                        // Console.Write($"{array1[i, j]}");
                    }
                    // Console.WriteLine();
                }
            }
            this.flowLayoutPanel2.Visible = true;
            flowLayoutPanel2.Width = (int)38 * colomsAmount ;
            flowLayoutPanel2.Height = (int)32 * rawsAmount;
            this.label5.Visible = true;

            // make panel 2
            for (int i = 0; i < rawsAmount; i++)
            {
                flowLayoutPanel2.Controls.Add(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, Height = 26 });

                for (int j = 0; j < colomsAmount ; j++)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel2.Controls[flowLayoutPanel2.Controls.Count - 1];
                    panel.Width = (int)38.5 * colomsAmount;
                    panel.Controls.Add(new TextBox { Width = 30, Height = 20, TextAlign = HorizontalAlignment.Center });

                }
            }

            for (int i = 0; i < rawsAmount; i++)
            {
                for (int j = 0; j < colomsAmount; j++)
                {
                    flowLayoutPanel2.Controls[i].Controls[j].Text = $"{array1[i, j] * multiplier}";

                }

            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 newform = new Form5();
            newform.Show();
        }
    }
}
