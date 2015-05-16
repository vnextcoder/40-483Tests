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
    internal class Square:IColor,IDraw
    {

        private int sideLength;
        private int x = 0, y = 0;
        private Rectangle rect = null;

        public Square(int sidelength)
        {
            this.sideLength = sidelength;
        }

        void IDraw.setLocation(int x, int y)
        {
            //throw new NotImplementedException();
            this.x = x;
            this.y = y;
        }

        void IDraw.Draw(System.Windows.Controls.Canvas canvas)
        {

            if (this.rect != null) 

            {
                canvas.Children.Remove(rect);
            }
            else
            {
                this.rect=new Rectangle();
            }

            this.rect.Width=sideLength;
            this.rect.Height=sideLength;
            Canvas.SetTop(this.rect, this.y);

            Canvas.SetLeft(this.rect, this.x);
            canvas.Children.Add(this.rect);


            //throw new NotImplementedException();
        }

        void IColor.changeColor(System.Windows.Media.Color color)
        {
            if (rect != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                this.rect.Fill = brush;

            }
            //throw new NotImplementedException();
        }
    }
}
