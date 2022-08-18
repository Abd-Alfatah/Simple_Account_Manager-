using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] cost_array;
        double orignal_amount, current_cost, cost;
        static int count()
        {
            int n = 0;
            StreamReader f = new StreamReader("Account.txt");

            while (!f.EndOfStream)
            {
                f.ReadLine();
                n++;
            }
            f.Close();
            return n;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                current_cost = 0;
            }
            else
            { current_cost = double.Parse(textBox1.Text); }
            string new_cost = current_cost.ToString();
            string line_1 = new_cost + ("*");
            StreamWriter l = new StreamWriter("Account.txt", true);
            l.WriteLine(line_1);
            textBox1.Clear();
            l.Close();
            MessageBox.Show("the cost was added successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int n = count();
            StreamReader f = new StreamReader("Account.txt");

            cost_array = new string[n];

            int j = 0;
            int i;
            while (!f.EndOfStream)
            {
                string line = f.ReadLine();

                i = line.IndexOf("*");
                cost_array[j] = line.Substring(0, i);
                //line = line.Remove(0, i + 1);
                j = j + 1;
            }
            double sum = 1;
            double s = 0;
            double[] d = new double[100];




            for (int k = 0; k < n; k++)
            {
                d[k] = double.Parse(cost_array[k]);
                s = d.Sum();
            }
            f.Close();

            orignal_amount = 5 * 15000;
            double reminder = orignal_amount - s;
            cost = 0;
            /* for (int i = 0; i < reminder.Length; i++)
             {
                 reminder[0] = current_cost;
                 if (reminder[i+1] != reminder[i])
                 {
                     reminder[i] = current_cost;
                      cost = reminder.Sum();
                 }
                 else
                     break;

             }*/
            orignal_amount = orignal_amount - s;
            MessageBox.Show("the current amount remined in your account is" + orignal_amount.ToString());

        }

        
    }
}
