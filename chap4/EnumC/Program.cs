using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace chap4 {
    class Program {
        // Import user32.dll (containing the function we need) and define
    // the method corresponding to the native function.
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);


        // Define a delegate that corresponds to the unmanaged function.
        delegate bool EnumWC(IntPtr hwnd, IntPtr lParam);

        // Import user32.dll (containing the function we need) and define
        // the method corresponding to the native function.
        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWC lpEnumFunc, IntPtr lParam);

        // Define the implementation of the delegate; here, we simply output the window handle.
        static bool OutputWindow(IntPtr hwnd, IntPtr lParam) {
            Console.WriteLine(hwnd.ToInt64());
            return true;
        }
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            int quantity;
            try {
                quantity = int.Parse ("123");
            } catch {
                quantity = 1;
            }
            int weight;
            if (!int.TryParse ("10", out weight)) weight = 10;

            Console.WriteLine (weight + "  " + quantity);

            var times = new [] {
                DateTime.Parse ("3:45 PM April 1, 2014").ToString ("MMM"),
                DateTime.Parse ("1 apr 2014 15:45").ToString ("MMM"),
                DateTime.Parse ("15:45 4/1/14").ToString ("MMM"),
                DateTime.Parse ("3:45pm 4.1.14").ToString ("MMM")
            };

            decimal amount = decimal.Parse ("123,456.78");//, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands);

            Array.ForEach (times, Console.WriteLine);

            Console.WriteLine (amount);

            int packedValue;
            // The API function call sets packedValue here.
            packedValue = int.MaxValue;

            unsafe
            {
                packedValue++;
            }
            // Convert the packed value into an array of bytes.
            byte[] valueBytes = BitConverter.GetBytes (packedValue);
            // Unpack the two values.
            short value1, value2;
            value1 = BitConverter.ToInt16 (valueBytes, 0);
            value2 = BitConverter.ToInt16 (valueBytes, 2);

            Console.WriteLine(value1)           ;
            Console.WriteLine(value2);
MessageBox(IntPtr.Zero, "Hello Atharva how are you ? I am good ", "Attention!", 0);

            EnumWindows(OutputWindow, IntPtr.Zero);
            
        }
    }
}