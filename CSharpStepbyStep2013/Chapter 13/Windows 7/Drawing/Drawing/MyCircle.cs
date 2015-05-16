using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Drawing
{
    public class MyCircle:IDraw,IColor
    {
        private int diameter;
        private int x = 0, y = 0;

        private Ellipse circle = null;
        public MyCircle(int diameter)
        {
            this.diameter = diameter;
        }
        
        void IDraw.setLocation(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        

        void IDraw.Draw(System.Windows.Controls.Canvas canvas)
        {

            if (circle != null)
            {
                canvas.Children.Remove(circle);
            }
            else
            {
                circle = new Ellipse();
            }

            this.circle.Height = diameter;
            this.circle.Width = diameter;
            Canvas.SetTop(this.circle, this.y);
            Canvas.SetLeft(this.circle, this.x);
            canvas.Children.Add(this.circle);





        }

        public void changeColor(System.Windows.Media.Color color)
        {
            //throw new NotImplementedException();
            if (this.circle != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                this.circle.Fill = brush;
            }
        }
    }
}
