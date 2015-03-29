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

        public override string ToString () {
            return Data;
        }
    }
}
