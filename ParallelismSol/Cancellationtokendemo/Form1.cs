using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cancellationtokendemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tokensource = new CancellationTokenSource();
        }
        private CancellationTokenSource tokensource = null;
        private async void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Stopwatch watch = Stopwatch.StartNew();

                button1.Enabled = false;
                tokensource = new CancellationTokenSource();
                CancellationToken Cancel2 = tokensource.Token;
                //Cancel2.ThrowIfCancellationRequested();
                Task<Double>[] taskArray = { Task<Double>.Run(() => DoComputation(1.0,Cancel2),Cancel2),
                                      Task<Double>.Run(() => DoComputation(100.0,Cancel2),Cancel2), 
                                      Task<Double>.Run(() => DoComputation(1000.0,Cancel2),Cancel2) };

                try
                {
                    foreach (var item in taskArray)
                    {

                        await item;
                    }
                }
                catch (Exception)
                {
                    
                    //do nithings;'
                }
                

                var results = new Double[taskArray.Length];
                double sum = 0;
                for (int i = 0; i < taskArray.Length; i++)
                {
                    results[i] = taskArray[i].Result;
                    listBox1.Items.Add(string.Format("{0:N1} {1}", results[i],
                                  i == taskArray.Length - 1 ? "= " : "+ "));
                    sum += results[i];
                }

                foreach (var item in taskArray)
                {

                    listBox1.Items.Add(string.Format("status - {0}",item.Status.ToString()));
                }
                listBox1.Items.Add(string.Format("{0:N1}", sum));
                listBox1.Items.Add(string.Format("watchend  {0}", watch.ElapsedMilliseconds));
            }
            finally
            {
                button1.Enabled = true;
            }
        }
        private Double DoComputation(Double start, CancellationToken canx)
        {
            Double sum = 0;
            for (var value = start; value <= start + 10; value += 1)
                sum += value;

            if (canx.IsCancellationRequested == true)
            {
                
                return sum;

            }

            Thread.Sleep(5000);
            if (canx.IsCancellationRequested == true)
            {
                
                return sum;

            }

            Thread.Sleep(5000);
            //this.listBox1.Items.Add("currentrhread " + Thread.CurrentThread.GetHashCode().ToString());
            return sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (tokensource != null)
            {
                tokensource.Cancel();
            }
            button2.Enabled = true;
        }

    }
}
