using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees {
    public class Tree {
        public List<Tree> children { get; private set; }

        public Tree () {
            children = new List<Tree> ();
        }

        public void addChild ( Tree c ) {
            children.Add ( c );
        }

        public bool isIsomorphic ( Tree other ) {
            return children.Count == other.children.Count &&
                children.Zip<Tree, Tree, bool> ( other.children, (a,b) => a.isIsomorphic(b) ).All<bool> ( b => b );
        }

        public override string ToString () {
            return '(' + String.Join ( "", children.Select<Tree, String> ( t => t.ToString () ) ) + ')';
        }
    }
}
