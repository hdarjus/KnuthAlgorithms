using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneratingTrees;
using GeneratingTrees.ForestRepresentations;

namespace UnitTests {
    [TestClass]
    public class ForestTest {
        List<String> pars;
        List<List<int>> lefts;
        List<List<int>> rights;

        public ForestTest () {
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
        public void Forest_Equal () {
            for ( int i = 0; i < pars.Count; i++ ) {
                Forest p = new Parentheses ( pars[i] );
                Forest b = new LeftRight ( lefts[i], rights[i] );
                Assert.AreEqual ( p, b );
            }
        }
    }
}
