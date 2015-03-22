using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneratingTrees;

namespace UnitTests {
    [TestClass]
    public class TreeTest {
        List<String> pars;
        List<List<int>> lefts;
        List<List<int>> rights;

        public TreeTest () {
            pars = new List<String> () {
                "", "()", "()()", "(())", "(()())",
                "((()))()", "()(())"
            };
            lefts = new List<List<int>> () {
                new List<int> (),
                new List<int> () {0},
                new List<int> () {0, 0},
                new List<int> () {2, 0},
                new List<int> () {2, 0, 0},
                new List<int> () {2, 3, 0, 0},
                new List<int> () {0, 3, 0}
            };
            rights = new List<List<int>> () {
                new List<int> (),
                new List<int> () {0},
                new List<int> () {2, 0},
                new List<int> () {0, 0},
                new List<int> () {0, 3, 0},
                new List<int> () {4, 0, 0, 0},
                new List<int> () {2, 0, 0}
            };
        }

        [TestMethod]
        public void Tree_Equal () {
            for ( int i = 0; i < pars.Count; i++ ) {
                TreeParentheses p = new TreeParentheses ( pars[i] );
                TreeBinaryLeftRight b = new TreeBinaryLeftRight ( lefts[i], rights[i] );
                Assert.IsTrue ( p.Equals ( b ), "Pars " + pars[i] );
            }
        }

        [TestMethod]
        public void Conversion_BLR2P () {
            for ( int i = 0; i < pars.Count; i++ ) {
                IEnumerable<Tuple<int, int>> list = lefts[i].Zip ( rights[i], Tuple.Create<int, int> );
                String actual = Tree.Conversion.BLR2P ( list.ToList () );
                Assert.AreEqual ( pars[i], actual );
            }
        }
    }
}
