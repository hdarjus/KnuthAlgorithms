using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees.ForestRepresentations {
    public static class Conversion {
            public static Nodes Convert2Nodes ( Forest f ) {
                if ( f == null )
                    throw new NullReferenceException ();
                if ( f is Nodes )
                    return (Nodes)f;
                else if ( f is Parentheses )
                    return P2N ( (Parentheses)f );
                else if ( f is LeftRight )
                    return P2N ( LR2P ( (LeftRight)f ) );
                else
                    throw new ArgumentException ();
            }

            /*
             * Parentheses to Nodes conversion
             */
            private static Nodes P2N ( Parentheses par ) {
                String p = par.Data;
                Nodes result = new Nodes ();
                int i = 0;
                while ( i < p.Length ) {
                    Stack<Tree> stack = new Stack<Tree> ();
                    bool end = false;
                    while ( !end ) {
                        if ( p[i] == '(' ) {
                            Tree t = new Tree ();
                            stack.Push ( t );
                        } else if (stack.Count == 0) {
                            throw new ArgumentException ("Bad parenthesizing");
                        } else if (stack.Count == 1) {
                            end = true;
                        } else {
                            Tree t = stack.Pop ();
                            stack.Peek ().addChild ( t );
                        }
                        i++;
                    }
                    result.addChild ( stack.Peek() );
                }
                return result;
            }

            /*
             * LeftRight to Parentheses conversion
             */
            public static Parentheses LR2P (LeftRight lr) {
                List<Tuple<int, int>> data = lr.Data;
                if ( data.Count < 0 )
                    throw new ArgumentException ();
                else if ( data.Count == 0 )
                    return new Parentheses ( "" );
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
                return new Parentheses ( s.ToString () );
            }
        }
}
