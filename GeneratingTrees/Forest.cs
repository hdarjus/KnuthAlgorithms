using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratingTrees.ForestRepresentations;

namespace GeneratingTrees {
    public abstract class Forest : IEquatable<Forest> {
        public bool Equals ( Forest other ) {
            if ( other == null )
                throw new NullReferenceException ();
            else
                return Conversion.Convert2Nodes ( this ).Equals ( Conversion.Convert2Nodes ( other ) );
        }

        public override bool Equals ( object obj ) {
            if (obj == null) 
                return false;
            Forest f = obj as Forest;
            if (f == null)
                return false;
            else    
                return Equals(f); 
        }

        public override int GetHashCode () {
            return Conversion.Convert2Nodes ( this ).ToString().GetHashCode ();
        }

        public static bool operator == (Forest f1, Forest f2) {
            if ( (object)f1 == null || ( (object)f2 ) == null )
                return Object.Equals ( f1, f2 );

            return f1.Equals ( f2 );
        }

        public static bool operator != (Forest f1, Forest f2) {
            if ( f1 == null || f2 == null )
                return !Object.Equals ( f1, f2 );

            return !( f1.Equals ( f2 ) );
        }
    }
}
