using System;
using System.Collections;
using System.Collections.Generic;
namespace IEnumerableTree {
    class TreeNode : IEnumerable<TreeNode> {

        public int Depth { get; set; }
        public string Text { get; set; }

        public List<TreeNode> Children = new List<TreeNode> ();

        public TreeNode (string text) {
            this.Text = text;
        }

        public TreeNode AddChild (TreeNode child) {
            child.Depth = this.Depth + 1;
            Children.Add (child);

            return child;
        }

        public TreeNode AddChild (string text) {
            TreeNode child = new TreeNode (text);
            return this.AddChild (child);
        }

        public IEnumerator<TreeNode> GetEnumerator () {
            return new TreeNodeEnumerator (this);
        }

        IEnumerator IEnumerable.GetEnumerator () {
            return new TreeNodeEnumerator (this);
        }

        public IEnumerable<TreeNode> GetTraversal () {
            // Get the preorder traversal.
            List<TreeNode> traversal = Preorder ();
            // Yield the nodes in the traversal.
            foreach (TreeNode node in traversal) 
                yield return node;
            yield break;
        }

        // Return the tree's nodes in an preorder traversal.
        public List<TreeNode> Preorder () {
            // Make the result list.
            List<TreeNode> nodes = new List<TreeNode> ();

            // Traverse this node's subtree.
            TraversePreorder (nodes);

            // Return the result.
            return nodes;
        }
        private void TraversePreorder (List<TreeNode> nodes) {
            // Traverse this node.
            nodes.Add (this);

            // Traverse the children.
            foreach (TreeNode child in Children)
                child.TraversePreorder (nodes);
        }
    }

}