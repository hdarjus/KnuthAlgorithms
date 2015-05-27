using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratingTrees;
using GeneratingTrees.ForestRepresentations;

namespace GUI {
    public class TableViewModel {
        public ObservableCollection<TableRow> ResultTable { get; set; }

        public TableViewModel () {
            ResultTable = new ObservableCollection<TableRow> ();
        }
    }

    public class TableRow {
        public ObservableCollection<Forest> Row { get; set; }
        public TableRow () {
            Row = new ObservableCollection<Forest> ();
        }
    }
}
