using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public MainWindow()
        {

            InitializeComponent();
            logger.Info("InitializeComponent run ");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (chkParallel.IsChecked == true)
            {
                logger.Info("Going parallel ");




                //Parallel.Invoke(() => DoWork(), () => DoWork2(),() => DosomeotherWork(),() => DosomeotherWork2());
                DoWorkall();

            }
            else
            {
                logger.Info("Going serial ");
                DoWork();
                DoWork2();
                DosomeotherWork();
                DosomeotherWork2();
            }

            watch.Stop();

            TimeSpan ts = watch.Elapsed;
            // Format and display the TimeSpan value. 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            logger.Info("RunTime " + elapsedTime);
            lblRunTime.Content = "RunTime " + elapsedTime;
        }
        private void DoWork()
        {
            for (int i = 1; i <= 100; i++)
            {
                double abc =Math.Round( Math.Sqrt(i),2);
                string logstring = string.Format(" dowork iteration {0} value - {1}", i, abc);

                    logger.Info( logstring);
                   // lstActionLog.Items.Add(logstring);

                Thread.Sleep(100);
            }
        
        }
        private void DoWork2()
        {
            for (int i = 101; i <= 200; i++)
            {
                double abc = Math.Round(Math.Sqrt(i), 2);
                string logstring = string.Format(" dowork2 iteration {0} value - {1}", i, abc);

                logger.Info(logstring);
                //lstActionLog.Items.Add(logstring);

                Thread.Sleep(100);
            }

        }
        private void DosomeotherWork()
        {
            for (int i = 201; i <=300 ; i++)
            {
                double abc = Math.Round(Math.Sqrt(i), 2);

                string logstring = string.Format(" DosomeotherWork iteration {0} value - {1}", i, abc);

                logger.Info(logstring);
               // lstActionLog.Items.Add(logstring);
                Thread.Sleep(100);
            }



        }
        private void DosomeotherWork2()
        {
            for (int i = 301; i <= 400; i++)
            {
                double abc = Math.Round(Math.Sqrt(i), 2);

                string logstring = string.Format(" DosomeotherWork2 iteration {0} value - {1}", i, abc);

                logger.Info(logstring);
               // lstActionLog.Items.Add(logstring);
                Thread.Sleep(100);
            }

        }


        private void DoWorkall()
        {
                Parallel.For(1, 400, j => worker(j));
            
        }
         private void worker(int i)
        {

            double abc =  Math.Round(Math.Sqrt(i), 2);
            string logstring = string.Format(" dowork iteration {0} value - {1}", i, abc);

            logger.Info(logstring);
            // lstActionLog.Items.Add(logstring);

            Thread.Sleep(100);
            return;
        }
    }
}
