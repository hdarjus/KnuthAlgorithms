using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees {
    public class BinaryTree : IEquatable<BinaryTree> {
        BinaryTreeNode root { get; set; }

        public BinaryTree ( BinaryTreeNode r ) {
            root = r;
        }

        public bool Equals ( BinaryTree other ) {
            if ( other == null )
                throw new NullReferenceException ();
            return root.isIsomorphic(other.root);
        }
    }

    public abstract class BinaryTreeNode {
        public abstract bool isIsomorphic ( BinaryTreeNode other);
    }

    public class BinaryNode : BinaryTreeNode {
        public BinaryTreeNode left { get; set; }
        public BinaryTreeNode right { get; set; }

        public override bool isIsomorphic ( BinaryTreeNode other ) {
            if ( other is BinaryNode ) {
                BinaryNode b = (BinaryNode)other;
                return left.isIsomorphic ( b.left ) && right.isIsomorphic ( b.right );
            } else
                return false;
        }
    }

    public class BinaryBin : BinaryTreeNode {
        public override bool isIsomorphic ( BinaryTreeNode other ) {
            return other is BinaryBin;
        }
    }
}
