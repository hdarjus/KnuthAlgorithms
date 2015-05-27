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

            List<Parentheses> pars = (new List<String> () {
                "", "()", "()()", "(())", "(()())",
                "((()))()", "()(())"
            }).Select<String, Parentheses>(s => new Parentheses (s)).ToList();
            List<List<int>> lefts = new List<List<int>> () {
                new List<int> (),
                new List<int> () {0},
                new List<int> () {0, 0},
                new List<int> () {2, 0},
                new List<int> () {2, 0, 0},
                new List<int> () {2, 3, 0, 0},
                new List<int> () {0, 3, 0}
            };
            List<List<int>> rights = new List<List<int>> () {
                new List<int> (),
                new List<int> () {0},
                new List<int> () {2, 0},
                new List<int> () {0, 0},
                new List<int> () {0, 3, 0},
                new List<int> () {4, 0, 0, 0},
                new List<int> () {2, 0, 0}
            };
            TableViewModel tvm = new TableViewModel ();
            for ( int i = 0; i < lefts.Count; i++ ) {
                TableRow row = new TableRow ();
                row.Row.Add ( pars[i] );
                row.Row.Add ( new LeftRight ( lefts[i], rights[i] ) );
                tvm.ResultTable.Add(row);
            }

            DataContext = tvm;
        }
    }
}
