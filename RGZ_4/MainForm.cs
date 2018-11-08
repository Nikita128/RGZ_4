using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;

namespace RGZ_4
{
    delegate double ObjectFunction(double u);

    public partial class MainForm : Form
    {
        private Form results = new Form
        {
            Width = 600,
            Height = 600,
            StartPosition = FormStartPosition.CenterScreen
        };

        private double[] alpha;
        private ObjectFunction[] functions;
        private ObjectFunction objectFunction;

        private Dictionary<double, double> originalObject;
        private Dictionary<double, double> model;

        private List<Matrix> alphaLog;

        public MainForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {         
            model = null;
            alpha = null;

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

            if (l1RadioButton.Checked)
            {
                functions = new ObjectFunction[1];
                functions[0] = (u => { return u; });
                alpha = new double[1] { 0 };

                objectFunction = Function.LinearFunction1;
            }
            else if (l2RadioButton.Checked)
            {
                functions = new ObjectFunction[2];
                functions[0] = (u => { return 1; });
                functions[1] = (u => { return u; });
                alpha = new double[2] { 0, 0 };

                objectFunction = Function.LinearFunction2;
            }
            else if (nl1RadioButton.Checked)
            {
                functions = new ObjectFunction[3];
                functions[0] = (u => { return 1; });
                functions[1] = (u => { return u; });
                functions[2] = (u => { return u * u; });
                alpha = new double[3] { 0, 0, 0 };

                objectFunction = Function.NonLinearFunction1;
            }
            else if (nl2RadioButton.Checked)
            {
                functions = new ObjectFunction[2];
                functions[0] = (u => { return 1; });
                functions[1] = (u => { return Math.Sin(u); });
                alpha = new double[2] { 0, 0 };

                objectFunction = Function.NonLinearFunction2;
            }
            else
            {
                MessageBox.Show("Выберите объект");
                return;
            }

            adaptButton.Enabled = true;
            showButton.Enabled = true;

            if (x1 > x2)
            {
                double t = x1;
                x1 = x2;
                x2 = t;
            }

            delta = (x2 - x1) / n;

            originalObject = new Dictionary<double, double>();

            for (double i = x1; i < x2; i += delta)
                originalObject.Add(i, objectFunction(i) + Statistics.MpcGenerator(m, 0, d, 1)[0]);
        }

        private double GetModel(double u)
        {            
            double result = 0;
            for (int i = 0; i < alpha.Length; i++)
                result += alpha[i] * functions[i](u);
            return result;                 
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (originalObject == null)
            {
                MessageBox.Show("Объект не был сгенерирован", "Ошибка");
                return;
            }

            double x1, x2, delta;
            int n;

            try
            {
                n = Convert.ToInt32(nTextBox.Text);
                x1 = Convert.ToDouble(x1TextBox.Text);
                x2 = Convert.ToDouble(x2TextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка ввода");
                return;
            }

            delta = Math.Abs(x1 - x2) / n;

            ScatterSeries orObj = new ScatterSeries()
            {
                Title = "Объект с помехой",
                MarkerType = MarkerType.Circle
            };

            foreach (var v in originalObject)
                orObj.Points.Add(new ScatterPoint(v.Key, v.Value, 1.8));

            FunctionSeries f = new FunctionSeries(T => { return objectFunction(T); }, x1, x2, delta)
            {
                Title = "Объект"
            };

            PlotModel plot = new PlotModel()
            {
                Title = "График"
            };

            PlotView view = new PlotView()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Model = plot
            };

            plot.Series.Add(orObj);
            plot.Series.Add(f);

            FunctionSeries modelFunctionSeries = null;

            if (model != null)
            {
                modelFunctionSeries = new FunctionSeries()
                {
                    Title = "Модель"
                };

                foreach(var t in model)                
                    modelFunctionSeries.Points.Add(new DataPoint(t.Key, t.Value));

                plot.Series.Add(modelFunctionSeries);
            }     

            results.Controls.Add(view);            

            results.Refresh();
            results.ShowDialog();
            results.Controls.Clear();
        }

        private void adaptButton_Click(object sender, EventArgs e)
        {
            /*Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < alpha.Length; i++)
                alpha[i] = r.Next(-10, 10);*/

            alpha.Fill(0);

            model = new Dictionary<double, double>();

            Matrix mAlpha = new Matrix(alpha);
            Matrix mFunc = new Matrix(functions.Length, 1);
            Matrix prevMAlpha = new Matrix(alpha);

            alphaLog = new List<Matrix>();

            foreach (var obj in originalObject)
            {
                for(int j = 0; j < functions.Length; j++)                
                    mFunc[j, 0] = functions[j](obj.Key);

                mAlpha = prevMAlpha + (((obj.Value.ToMatrix() - (mFunc.T() * prevMAlpha)) / (5 + (mFunc.T() * mFunc))) * mFunc);
                alphaLog.Add(mAlpha);
                prevMAlpha = mAlpha;

                /*for (int i = 0; i < mAlpha.RowCount; i++)
                    prevMAlpha[i, 0] = mAlpha[i, 0];*/
            }

            for (int i = 0; i < alpha.Length; i++)
                alpha[i] = mAlpha[i, 0];

            for (int i = 0; i < originalObject.Count; i++)            
                model.Add(originalObject.ElementAt(i).Key, GetModel(originalObject.ElementAt(i).Key));

        }

        private void l1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            adaptButton.Enabled = false;
            showButton.Enabled = false;
        }

        private void l2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            adaptButton.Enabled = false;
            showButton.Enabled = false;
        }

        private void nl1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            adaptButton.Enabled = false;
            showButton.Enabled = false;
        }

        private void nl2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            adaptButton.Enabled = false;
            showButton.Enabled = false;
        }
    }
}
