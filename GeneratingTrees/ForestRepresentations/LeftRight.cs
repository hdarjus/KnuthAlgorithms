using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees.ForestRepresentations {
    public class LeftRight : Forest {
        public List<Tuple<int,int>> Data { get; private set; }

        public LeftRight ( List<int> left, List<int> right ) {
            int length = Math.Max ( 0, Math.Min ( left.Count, right.Count ) );
            Data = new List<Tuple<int, int>> ( length );
            for ( int i = 0; i < length; i++ ) {
                Data.Add ( new Tuple<int, int> ( left[i], right[i] ) );
            }
        }

        public override string ToString () {
            List<String> l = new List<String> ();
            List<String> r = new List<String> ();
            for ( int i = 0; i < Data.Count; i++ ) {
                l.Add ( Data[i].Item1.ToString () );
                r.Add ( Data[i].Item2.ToString () );
            }
            return '[' + String.Join ( ", ", l.ToArray () ) + "] [" + String.Join ( ", ", r.ToArray () ) + ']';
        }
    }
}
