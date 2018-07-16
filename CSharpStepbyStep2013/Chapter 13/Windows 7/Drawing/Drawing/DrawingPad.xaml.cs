using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drawing
{
    public partial class DrawingPadWindow : Window
    {
        public DrawingPadWindow()
        {
            InitializeComponent();
        }

        private void drawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mouselocation = e.GetPosition(this.drawingCanvas);
            Square square = new Square(100);
            if (square is IDraw)
            {

                IDraw drawinginterface = square;
                drawinginterface.setLocation((int)mouselocation.X, (int)mouselocation.Y);
                drawinginterface.Draw(drawingCanvas);

            }
            if (square is IColor) 
            {
                IColor col = square;
                col.changeColor(Colors.DarkBlue);
            }
        }

        private void drawingCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mouselocation = e.GetPosition(this.drawingCanvas);
            MyCircle circle = new MyCircle(120);
            if (circle is IDraw)

            {
                IDraw drawinginterface = circle;
                drawinginterface.setLocation((int)mouselocation.X, (int)mouselocation.Y);
                drawinginterface.Draw(drawingCanvas);
            }
            
            if (circle is IColor) 
            {
                IColor col = circle;
                col.changeColor(Colors.HotPink);
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            

        }       
    }
}
