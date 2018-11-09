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
        private ObjectFunction[] gradient;
        private ObjectFunction objectFunction;

        private Functions funcType;

        private Dictionary<double, double> originalObject;
        private Dictionary<double, double> model;

        private List<double[]> alphaLog;

        public MainForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {         
            model = null;
            alpha = null;
            resultRichTextBox.Text = "";

            double m, d, delta;
            int n;

            try
            {
                m = Convert.ToDouble(mTextBox.Text);
                d = Convert.ToDouble(dTextBox.Text);
                n = Convert.ToInt32(nTextBox.Text);
                delta = Convert.ToDouble(duTextBox.Text);
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
                funcType = Functions.Linear_1;
            }
            else if (l2RadioButton.Checked)
            {
                functions = new ObjectFunction[2];
                functions[0] = (u => { return 1; });
                functions[1] = (u => { return u; });
                alpha = new double[2] { 0, 0 };

                objectFunction = Function.LinearFunction2;
                funcType = Functions.Linear_2;
            }
            else if (nl1RadioButton.Checked)
            {
                functions = new ObjectFunction[3];
                functions[0] = (u => { return 1; });
                functions[1] = (u => { return u; });
                functions[2] = (u => { return u * u; });

                gradient = new ObjectFunction[3];
                gradient[0] = (u => { return 1; });
                gradient[1] = (u => { return u; });
                gradient[2] = (u => { return u * u; });

                alpha = new double[3] { 0, 0, 0 };

                objectFunction = Function.NonLinearFunction1;
                funcType = Functions.NonLinear_1;
            }
            else if (nl2RadioButton.Checked)
            {
                functions = new ObjectFunction[2];
                /*functions[0] = (u => { return Math.Sin(u); });
                functions[1] = (u => { return Math.Cos(u); });*/

                gradient = new ObjectFunction[2];
                /*gradient[0] = (u => { return Math.Sin(u); });
                gradient[1] = (u => { return Math.Cos(u); });*/

                gradient[0] = (u => { return Math.Pow(u, alpha[1]); });
                gradient[1] = (u => { return alpha[0] * Math.Pow(u, alpha[1]) * Math.Log(u); });

                alpha = new double[2] { 0, 0 };

                objectFunction = Function.NonLinearFunction2;
                funcType = Functions.NonLinear_2;
            }
            else
            {
                MessageBox.Show("Выберите объект");
                return;
            }

            adaptButton.Enabled = true;
            showButton.Enabled = true;

            originalObject = new Dictionary<double, double>();

            for (double i = 0.01; i < delta * n; i += delta)
                originalObject.Add(i, objectFunction(i) + Statistics.MpcGenerator(m, 0, d, 1)[0]);
        }

        private double GetModel(double u)
        {
            if (funcType == Functions.NonLinear_2)
                return alpha[0] * Math.Pow(u, alpha[1]);

            double result = 0;
            for (int i = 0; i < alpha.Length; i++)
                result += alpha[i] * functions[i](u);
            return result;                 
        }

        private double GetModel(double u, Matrix mAlpha)
        {
            if (funcType == Functions.NonLinear_2)
                return mAlpha[0, 0] * Math.Pow(u, mAlpha[1, 0]);

            double result = 0;

            for (int i = 0; i < mAlpha.RowCount; i++)
                result += mAlpha[i, 0] * functions[i](u);
            return result;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (originalObject == null)
            {
                MessageBox.Show("Объект не был сгенерирован", "Ошибка");
                return;
            }

            double delta;
            int n;

            try
            {
                n = Convert.ToInt32(nTextBox.Text);
                delta = Convert.ToDouble(duTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка ввода");
                return;
            }

            results.Width = 600;

            ScatterSeries orObj = new ScatterSeries()
            {
                Title = "Объект с помехой",
                MarkerType = MarkerType.Circle
            };

            foreach (var v in originalObject)
                orObj.Points.Add(new ScatterPoint(v.Key, v.Value, 1.8));

            FunctionSeries f = new FunctionSeries(T => { return objectFunction(T); }, 0.01, delta * n, delta)
            {
                Title = "Объект"
            };

            PlotModel plot = new PlotModel()
            {
                Title = "График модели и объекта"
            };

            PlotView view = new PlotView()
            {
                Dock = DockStyle.Fill,
                Height = 550,
                Width = 550,
                BackColor = Color.White,
                Model = plot
            };

            plot.Series.Add(orObj);
            plot.Series.Add(f);

            FunctionSeries modelFunctionSeries = null;
            PlotModel alphaPlot = null;
            PlotView alphaView = null;
            FunctionSeries[] alphaSeries = null;

            if (model != null)
            {
                results.Width = 1150;

                alphaSeries = new FunctionSeries[alpha.Length];
                for (int i = 0; i < alphaSeries.Length; i++)
                    alphaSeries[i] = new FunctionSeries()
                    {
                        Title = "Alpha" + (i + 1)
                    };
                
                for (int i = 0; i < alphaLog.Count; i++)
                {
                    for (int j = 0; j < alphaSeries.Length; j++)
                        alphaSeries[j].Points.Add(new DataPoint(i, alphaLog.ElementAt(i)[j]));
                }

                alphaPlot = new PlotModel()
                {
                    Title = "График подстройки параметров"
                };

                alphaView = new PlotView()
                {
                    Dock = DockStyle.Right,
                    Height = 550,
                    Width = 550,
                    BackColor = Color.White,
                    Model = alphaPlot
                };

                view.Dock = DockStyle.Left;

                modelFunctionSeries = new FunctionSeries()
                {
                    Title = "Модель"
                };

                foreach(var t in model)                
                    modelFunctionSeries.Points.Add(new DataPoint(t.Key, t.Value));

                plot.Series.Add(modelFunctionSeries);

                for (int i = 0; i < alphaSeries.Length; i++)
                    alphaPlot.Series.Add(alphaSeries[i]);
            }

            results.Controls.Add(view);
            results.Controls.Add(alphaView);

            results.Refresh();
            results.ShowDialog();
            results.Controls.Clear();
        }

        private void adaptButton_Click(object sender, EventArgs e)
        {
            double g;

            try
            {
                g = Convert.ToDouble(gTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка ввода");
                return;
            }

            alpha.Fill(0.1);

            model = new Dictionary<double, double>();

            Matrix mAlpha = new Matrix(alpha);
            Matrix mFunc = new Matrix(functions.Length, 1);
            Matrix prevMAlpha = new Matrix(alpha);

            alphaLog = new List<double[]>();

            foreach (var obj in originalObject)
            {
                if (funcType == Functions.Linear_1 || funcType == Functions.Linear_2)
                {
                    for (int j = 0; j < functions.Length; j++)
                        mFunc[j, 0] = functions[j](obj.Key);

                    mAlpha = prevMAlpha + (((obj.Value - (mFunc.T() * prevMAlpha)[0, 0]) / (g + (mFunc.T() * mFunc)[0, 0])) * mFunc);
                }
                else if (funcType == Functions.NonLinear_1 || funcType == Functions.NonLinear_2)
                {
                    for (int j = 0; j < functions.Length; j++)
                        mFunc[j, 0] = gradient[j](obj.Key);

                    mAlpha = prevMAlpha + (((obj.Value - GetModel(obj.Key, prevMAlpha)) /
                        ((mFunc.T() * GetModel(obj.Key, prevMAlpha) * mFunc * GetModel(obj.Key, prevMAlpha))[0, 0] + g)) * (mFunc * GetModel(obj.Key, prevMAlpha)));
                }

                alphaLog.Add(alpha);
                //prevMAlpha = mAlpha;

                for (int j = 0; j < alpha.Length; j++)
                    prevMAlpha[j, 0] = mAlpha[j, 0];

                alpha = mAlpha.ToArray();
            }

            String resultString = "";

            for (int i = 0; i < alpha.Length; i++)
            {
                alpha[i] = mAlpha[i, 0];
                resultString += "Alpha" + (i + 1) + " = " + alpha[i] + ";\n";
            }

            resultRichTextBox.Text = resultString;

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
