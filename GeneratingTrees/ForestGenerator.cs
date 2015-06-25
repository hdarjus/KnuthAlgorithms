using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratingTrees.ForestRepresentations;

namespace GeneratingTrees {
    public static class ForestGenerator {
        /*
         * Nested parentheses in lexicographic order
         */
        public static List<Forest> AlgorithmP ( int n ) {
            if ( n < 0 )
                throw new ArgumentOutOfRangeException ( "Non-negative number expected" );
            List<Forest> result = new List<Forest> ();
            if ( n == 1 )
                result.Add ( new Parentheses ( "()" ) );
            if ( n <= 1 )
                return result;
            StringBuilder a = new StringBuilder ();
            int m = 2 * n - 1;
            a.Append ( ')' );
            for ( int i = 1; i <= 2*n; i++ ) {
                a.Append ( i % 2 == 0 ? ')' : '(' );
            }
            bool end = false;
            while ( !end ) {
                result.Add ( new Parentheses ( a.ToString ( 1, 2 * n ) ) );
                a[m] = ')';
                if ( a[m - 1] == ')' ) {
                    a[m - 1] = '(';
                    m--;
                } else {
                    int j = m - 1;
                    int k = 2 * n - 1;
                    while ( a[j] == '(' ) {
                        a[j] = ')';
                        a[k] = '(';
                        j--; k -= 2;
                    }
                    if ( j == 0 )
                        end = true;
                    else {
                        a[j] = '(';
                        m = 2 * n - 1;
                    }
                }
            }
            return result;
        }

        // Convert from list of 1 based left parenthesis indices to string of parentheses
        private static String ZtoP ( List<int> z ) {
            int n = z.Count;
            StringBuilder res = new StringBuilder ( 2 * n );
            for ( int i = 0; i < 2 * n; i++ )
                res.Append ( ')' );
            for ( int i = 0; i < n; i++ )
                res[z[i]-1] = '(';
            return res.ToString ();
        }

        public static List<Forest> AlgorithmN ( int n ) {
            if ( n < 0 )
                throw new ArgumentOutOfRangeException ( "Non-negative number expected" );
            List<Forest> result = new List<Forest> ();
            if ( n == 0 )
                return result;
            List<int> z = ( from j in Enumerable.Range ( 0, n ) select 2 * j + 1 ).ToList<int> ();
            List<int> g = ( from j in Enumerable.Range ( 0, n ) select 2 * j ).ToList<int> ();
            bool end = false;
            while ( !end ) {
                result.Add ( new Parentheses ( ZtoP ( z ) ) );
                int j;
                for ( j = n - 1; j >= 0 && g[j] == z[j]; j-- ) {
                    g[j] = g[j] ^ 1;
                }
                if ( ( g[j] - z[j] ) % 2 == 0 ) {
                    z[j] += 2;
                } else {
                    int t = z[j] - 2;
                    if ( t < 0 )
                        end = true;
                    else {
                        if ( t <= z[j - 1] )
                            t += 1 + ( t < z[j - 1] ? 2 : 0 );
                        z[j] = t;
                    }
                }
            }
            return result;
        }
    }
}
