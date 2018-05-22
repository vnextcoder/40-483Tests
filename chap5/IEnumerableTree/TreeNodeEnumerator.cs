using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableTree {
    internal class TreeNodeEnumerator : IEnumerator<TreeNode> {
        private List<TreeNode> nodes;
        private int CurrentIndex=-1;

        public TreeNodeEnumerator (TreeNode root) {
            nodes = root.Preorder ();
        }

        public TreeNode Current => GetCurrent ();

        object IEnumerator.Current => GetCurrent ();

        private TreeNode GetCurrent () {
            if (CurrentIndex < 0 || CurrentIndex >= nodes.Count)
                throw new InvalidOperationException ();
            return nodes[CurrentIndex];
        }
        public void Dispose () {
            nodes = null;
        }

        public bool MoveNext () {
            
            CurrentIndex++;
            Console.WriteLine("current is " + CurrentIndex);
            return (CurrentIndex < nodes.Count);

        }

        public void Reset () {
            this.CurrentIndex = -1;
            Console.WriteLine("current is " + CurrentIndex);
        }
    }
}