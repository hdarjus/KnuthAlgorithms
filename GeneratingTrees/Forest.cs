using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratingTrees.ForestRepresentations;

namespace GeneratingTrees {
    public abstract class Forest : IEquatable<Forest> {
        public abstract bool Equals ( Forest other );

        public static class Conversion {
            public static Nodes Convert2Nodes ( Forest f ) {
                if ( f == null )
                    throw new NullReferenceException ();
                if ( f is Nodes )
                    return (Nodes)f;
                else
                    throw new ArgumentException ();
            }
            /*
             * LeftRight to Parentheses conversion
             */
            public static String LR2P (List<Tuple<int,int>> data) {
                if ( data.Count < 0 )
                    throw new ArgumentException ();
                else if ( data.Count == 0 )
                    return "";
                StringBuilder s = new StringBuilder ( 2 * data.Count );
                Stack<int> stack = new Stack<int> ( data.Count );
                s.Append ( '(' );
                stack.Push ( 1 );
                while ( stack.Count > 0 ) {
                    int t = stack.Peek ();
                    if ( data[t - 1].Item1 == 0 ) {
                        t = stack.Pop ();
                        s.Append ( ')' );
                        while ( stack.Count > 0 && data[t-1].Item2 == 0 ) {
                            t = stack.Pop ();
                            s.Append ( ')' );
                        }
                        if ( data[t-1].Item2 != 0 ) {
                            s.Append ( '(' );
                            stack.Push ( data[t - 1].Item2 );
                        }
                    } else {
                        s.Append ( '(' );
                        stack.Push ( data[t - 1].Item1 );
                    }
                }
                return s.ToString ();
            }
        }
    }
}
