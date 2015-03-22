using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees {
    public abstract class Tree : IEquatable<Tree> {
        public abstract bool Equals ( Tree other );

        public static class Conversion {
            /*
             * BinaryLeftRight to Parentheses conversion
             */
            public static String BLR2P (List<Tuple<int,int>> data) {
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

    public class TreeParentheses : Tree {
        public String Data { get; private set; }

        public TreeParentheses ( String d ) {
            Data = d;
        }

        public override bool Equals ( Tree other ) {
            if ( other == null )
                throw new NullReferenceException ();
            if ( other is TreeParentheses ) {
                return Data == ( (TreeParentheses)other ).Data;
            } else if (other is TreeBinaryLeftRight) {
                return Data == Conversion.BLR2P(( (TreeBinaryLeftRight)other ).Data);
            } else
                throw new ArgumentException ();
        }
    }

    public class TreeBinaryLeftRight : Tree {
        public List<Tuple<int,int>> Data { get; private set; }

        public TreeBinaryLeftRight ( List<int> left, List<int> right ) {
            int length = Math.Max ( 0, Math.Min ( left.Count, right.Count ) );
            Data = new List<Tuple<int, int>> ( length );
            for ( int i = 0; i < length; i++ ) {
                Data.Add ( new Tuple<int, int> ( left[i], right[i] ) );
            }
        }

        public override bool Equals ( Tree other ) {
            if ( other == null )
                throw new NullReferenceException ();
            if (other is TreeBinaryLeftRight) {
                return Data == ( (TreeBinaryLeftRight)other ).Data;
            } else if ( other is TreeParentheses ) {
                return Conversion.BLR2P(Data) == ( (TreeParentheses)other ).Data;
            } else
                throw new ArgumentException ();
        }
    }
}
