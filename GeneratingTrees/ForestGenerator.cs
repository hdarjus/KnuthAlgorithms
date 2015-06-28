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
            List<Forest> result = new List<Forest> ( Catalan ( n ) );
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

        // Nested parentheses, different method
        public static List<Forest> AlgorithmN ( int n ) {
            if ( n < 0 )
                throw new ArgumentOutOfRangeException ( "Non-negative number expected" );
            List<Forest> result = new List<Forest> ( Catalan ( n ) );
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

        // Binary left right representation
        public static List<Forest> AlgorithmB ( int n ) {
            if ( n < 0 )
                throw new ArgumentOutOfRangeException ( "Non-negative number expected" );
            List<Forest> result = new List<Forest> ( Catalan ( n ) );
            if ( n == 0 )
                return result;
            List<int> l = new List<int> ( n + 1 );
            List<int> r = new List<int> ( n );
            for ( int i = 0; i < n-1; i++ ) {
                l.Add ( i + 2 );
                r.Add ( 0 );
            }
            l.Add ( 0 );
            r.Add ( 0 );
            l.Add ( 1 );
            bool end = false;
            while ( !end ) {
                result.Add ( new LeftRight ( l, r ) );
                int j;
                for ( j = 0; j < n && l[j] == 0; j++ ) {
                    r[j] = 0;
                    l[j] = j + 2;
                }
                if ( j == n )
                    end = true;
                else {
                    int y = l[j]-1;
                    int k = 0;
                    while ( r[y] > 0 ) {
                        k = y;
                        y = r[y]-1;
                    }
                    if ( k > 0 )
                        r[k] = 0;
                    else
                        l[j] = 0;
                    r[y] = r[j];
                    r[j] = y+1;
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

        private static int Catalan ( int n ) {
            int[] c = { 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190 };
            if ( n >= c.Length )
                throw new NotImplementedException ();
            else
                return c[n];
        }
    }
}
