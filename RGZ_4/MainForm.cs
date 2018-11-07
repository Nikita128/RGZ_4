using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGZ_4
{
    delegate double ObjectFunction(double u);

    public partial class MainForm : Form
    {
        private double[] alpha;
        private ObjectFunction[] functions;

        public MainForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            double m, d, x1, x2, delta;
            int n;

            try
            {
                m = Convert.ToDouble(mTextBox.Text);
                d = Convert.ToDouble(dTextBox.Text);
                n = Convert.ToInt32(nTextBox.Text);
                x1 = Convert.ToDouble(x1TextBox.Text);
                x2 = Convert.ToDouble(x2TextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка ввода");
                return;
            }

            
        }

        private double GetModel(double u)
        {
            if (alpha.Length == functions.Length)
            {
                double result = 0;
                for (int i = 0; i < 0; i++)
                    result += alpha[i] * functions[i](u);
                return result;
            }
            return 101;
        }
    }
}
