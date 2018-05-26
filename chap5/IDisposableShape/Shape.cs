using System;
using System.Drawing;
namespace IDisposableShape {
    public class Shape : IDisposable, IComparable<Shape> {
        // The FillBrush and OutlinePen properties.    
        public Brush myBrush { get; set; }
        public Pen outlinePen { get; set; }

        // Remember whether we've already run Dispose.
        private bool IsDisposed = false;

        // Clean up managed resources.
        public void Dispose () {
            Console.WriteLine("Disposing the Managed Resources");
            // If we've already run Dispose, do nothing.

            if (IsDisposed) return;
            // Dispose of FillBrush and OutlinePen.
            FillBrush.Dispose ();
            OutlinePen.Dispose ();
            // Remember that we ran Dispose.
            IsDisposed = true;
        }

        ~Shape(){

            Console.WriteLine("Disposing the Unmanaged Resources");
        }
    }

}