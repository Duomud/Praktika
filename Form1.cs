using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Работа_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "текст|*.txt";
            openFileDialog1.Title = "Открыть документ с результатами опроса";
            openFileDialog1.Multiselect = false;

            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "текст|*.txt";
            saveFileDialog1.Title = "Сохранить документ с результатами опроса";
        }
        Вирус[] B;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = comboBox1.SelectedIndex;
                B[i].Count++;
            }
            catch
            {
                MessageBox.Show("Ошибка формата данных!");
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {

            }
            if (tabControl1.SelectedIndex == 1)
            {
                Вирус.Show(B, dataGridView1);
            }
            if (tabControl1.SelectedIndex == 2)
            {
                Diagram();
            }
        }
        private void Diagram()
        {
            chart1.Series.Add(new Series("ColumnSeries") { ChartType = SeriesChartType.BoxPlot});
            string[] xValues = new string[B.Length];
            double[] yValues = new double[B.Length];
            for (int i = 0; i < B.Length; i++)
            {
                xValues[i] = B[i].Name;
                yValues[i] = B[i].Count;
            }
            chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int K = comboBox1.Items.Count;
            B = new Вирус[K];
            for (int i = 0; i < K; i++)
            {
                B[i] = new Вирус(comboBox1.Items[i].ToString(), 0);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() ==DialogResult.OK)
            {
                Вирус.OpenFile(label1, comboBox1, ref B, openFileDialog1.Filter);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Вирус.SaveToFile(label1.Text, B.Length, B, saveFileDialog1.Filter);
            }

        }
    }

}
