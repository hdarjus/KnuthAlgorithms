using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeneratingTrees;
using GeneratingTrees.ForestRepresentations;

namespace GUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {
        public MainWindow () {
            InitializeComponent ();
        }

        private void fillTable ( List<Forest> col ) {
            if ( col == null || col.Count == 0 )
                return;
            TableViewModel tvm = new TableViewModel ();
            for ( int i = 0; i < col.Count; i++ ) {
                TableRow row = new TableRow ();
                row.Row.Add ( col[i] );
                tvm.ResultTable.Add ( row );
            }
            DataContext = tvm;
        }

        private void RunButtonClick ( object sender, RoutedEventArgs e ) {
            int n;
            bool validN = Int32.TryParse ( nTextBox.Text, out n );
            if ( validN && n > 0 ) {
                List<Forest> result;
                if ( rbAlgorithmN.IsChecked == true ) {
                    result = new List<Forest> ();
                } else if ( rbAlgorithmP.IsChecked == true ) {
                    result = ForestGenerator.AlgorithmP ( n );
                } else {
                    return;
                }
                fillTable ( result );
            }
        }
    }
}
