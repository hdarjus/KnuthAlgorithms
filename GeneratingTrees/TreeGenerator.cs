using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees {
    public static class TreeGenerator {
        /*
         * Nested parentheses in lexicographic order
         */
        public static ICollection<String> AlgorithmP ( int n ) {
            if ( n < 0 )
                throw new ArgumentOutOfRangeException ( "Non-negative number expected" );
            List<String> result = new List<String> ();
            if ( n == 1 ) {
                result.Add ( "()" );
            } else if ( n >= 2 ) {
                StringBuilder a = new StringBuilder ();
                int m = 2 * n - 1;
                a.Append ( ')' );
                for ( int i = 1; i <= 2*n; i++ ) {
                    a.Append ( i % 2 == 0 ? ')' : '(' );
                }
                bool end = false;
                while ( !end ) {
                    result.Add ( a.ToString ( 1, 2 * n ) );
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
            }
            return result;
        }
    }
}
