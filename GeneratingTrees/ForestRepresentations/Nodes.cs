using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees.ForestRepresentations {
    public class Nodes : Forest {
        public List<Tree> children { get; private set; }

        public Nodes () {
            children = new List<Tree> ();
        }

        public void addChild ( Tree c ) {
            children.Add ( c );
        }

        private bool isIsomorphic ( Nodes other ) {
            return children.Count == other.children.Count &&
                children.Zip<Tree, Tree, bool> ( other.children, (a,b) => a.isIsomorphic(b) ).All<bool> ( b => b );
        }

        public new bool Equals ( Forest other ) {
            if ( other == null )
                throw new NullReferenceException ();
            Nodes n = other is Nodes ? (Nodes)other : Conversion.Convert2Nodes ( other );
            return this.isIsomorphic ( n );
        }

        public override string ToString () {
            return String.Join ( "", children.Select<Tree, String> ( t => t.ToString () ) );
        }
    }
}
