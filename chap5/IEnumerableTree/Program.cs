using System;
using System.Collections.Generic;
namespace IEnumerableTree {
    class Program {
        static void Main (string[] args) {
            // Build the tree.
            TreeNode president = new TreeNode ("President");
            TreeNode sales = president.AddChild ("VP Sales");
            sales.AddChild ("Domestic Sales");
            sales.AddChild ("International Sales");
            sales.AddChild ("Sales Partners");
            TreeNode production = president.AddChild ("VP Production");
            production.AddChild ("CA Plant");
            production.AddChild ("HI Plant");
            production.AddChild ("NY Plant");
            production.AddChild ("Overseas Production");
            TreeNode marketing = president.AddChild ("VP Marketing");
            marketing.AddChild ("Television");
            marketing.AddChild ("Print Media");
            marketing.AddChild ("Electronic Marketing");

            // Display the tree.
            string text = "";
            IEnumerator<TreeNode> enumerator = president.GetEnumerator ();
            while (enumerator.MoveNext ())
            {
                text += new string (' ', 4 * enumerator.Current.Depth) +
                enumerator.Current.Text +
                Environment.NewLine;
            } 
            
                
            text = text.Substring (0, text.Length - Environment.NewLine.Length);
            Console.WriteLine (text);
            //String text="";
            Console.WriteLine ("Now using For Loop");
            text = "";
            foreach (var n in president) {
                text += new string (' ', 4 * n.Depth) +
                    n.Text +
                    Environment.NewLine;

                //Console.WriteLine(new string (' ', 4 * n.Depth) +                    n.Text );

            }
            text = text.Substring (0, text.Length - Environment.NewLine.Length);
            Console.WriteLine (text);

            text="";
            Console.WriteLine ("Now using For Loop with GetTraversal");
            foreach (var n in president.GetTraversal()) {
                text += new string (' ', 4 * n.Depth) +
                    n.Text +
                    Environment.NewLine;

            }
            text = text.Substring (0, text.Length - Environment.NewLine.Length);
            Console.WriteLine (text);


        }
    }
}