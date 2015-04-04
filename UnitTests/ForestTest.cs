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
        List<String> pars, nPars;
        List<List<int>> lefts, nLefts;
        List<List<int>> rights, nRights;

        public ForestTest () {
            pars = new List<String> () {
                "", "()", "()()", "(())", "(()())",
                "((()))()", "()(())"
            };
            nPars = new List<String> () {
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
            nLefts = new List<List<int>> () {
                new List<int> () {2, 0, 0},
                new List<int> () {2, 3, 0, 0},
                new List<int> () {0, 3, 0},
                new List<int> (),
                new List<int> () {0},
                new List<int> () {0, 0},
                new List<int> () {2, 0}
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
            nRights = new List<List<int>> () {
                new List<int> () {0, 3, 0},
                new List<int> () {4, 0, 0, 0},
                new List<int> () {2, 0, 0},
                new List<int> (),
                new List<int> () {0},
                new List<int> () {2, 0},
                new List<int> () {0, 0}
            };
        }

        [TestMethod]
        public void Forest_Equal () {
            for ( int i = 0; i < pars.Count; i++ ) {
                Forest p = new Parentheses ( pars[i] );
                Forest b = new LeftRight ( lefts[i], rights[i] );
                Forest np = new Parentheses ( nPars[i] );
                Forest nb = new LeftRight ( nLefts[i], nRights[i] );
                Assert.AreEqual ( p, b );
                Assert.AreNotEqual ( np, nb );
            }
        }
    }
}
