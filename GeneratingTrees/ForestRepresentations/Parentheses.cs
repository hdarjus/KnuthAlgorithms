using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingTrees.ForestRepresentations {
    public class Parentheses : Forest {
        public String Data { get; private set; }

        public Parentheses ( String d ) {
            Data = d;
        }

        public override bool Equals ( Forest other ) {
            if ( other == null )
                throw new NullReferenceException ();
            if ( other is Parentheses ) {
                return Data == ( (Parentheses)other ).Data;
            } else if (other is LeftRight) {
                return Data == Conversion.LR2P(( (LeftRight)other ).Data);
            } else
                throw new ArgumentException ();
        }
    }
}
