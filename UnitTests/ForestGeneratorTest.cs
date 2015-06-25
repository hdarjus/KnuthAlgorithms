using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneratingTrees;
using GeneratingTrees.ForestRepresentations;

namespace UnitTests {
    [TestClass]
    public class ForestGeneratorTest {
        // From the book
        ICollection<String> nestedPar4 = new HashSet<String> () {
            "()()()()", "()()(())", "()(())()", "()(()())",
            "()((()))", "(())()()", "(())(())", "(()())()",
            "(()()())", "(()(()))", "((()))()", "((())())",
            "((()()))", "(((())))"
        };

        [TestMethod]
        public void AlgorithmP_0 () {
            Assert.IsTrue ( ForestGenerator.AlgorithmP ( 0 ).Count == 0 );
        }

        [TestMethod, Timeout(100)]
        public void AlgorithmP_1 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmP ( 1 );
            Assert.IsTrue ( result.Count == 1 );
            Assert.IsTrue ( result.Contains ( new Parentheses ( "()" ) ) );
        }

        [TestMethod]
        public void AlgorithmP_4 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmP ( 4 );

            Assert.IsTrue ( result.Count == nestedPar4.Count );
            Assert.IsTrue ( nestedPar4.All<String> ( e => result.Contains ( new Parentheses ( e ) ) ) );
        }
        
        [TestMethod]
        public void AlgorithmN_0 () {
            Assert.IsTrue ( ForestGenerator.AlgorithmN ( 0 ).Count == 0 );
        }

        [TestMethod, Timeout(100)]
        public void AlgorithmN_1 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmN ( 1 );
            Assert.IsTrue ( result.Count == 1 );
            Assert.IsTrue ( result.Contains ( new Parentheses ( "()" ) ) );
        }

        [TestMethod]
        public void AlgorithmN_4 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmN ( 4 );

            Assert.IsTrue ( result.Count == nestedPar4.Count );
            Assert.IsTrue ( nestedPar4.All<String> ( e => result.Contains ( new Parentheses ( e ) ) ) );
        }
    }
}
