using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneratingTrees;

namespace UnitTests {
    [TestClass]
    public class TreeGeneratorTests {
        [TestMethod]
        public void AlgorithmP_0 () {
            Assert.IsTrue ( TreeGenerator.AlgorithmP ( 0 ).Count == 0 );
        }

        [TestMethod, Timeout(100)]
        public void AlgorithmP_1 () {
            ICollection<String> result = TreeGenerator.AlgorithmP ( 1 );
            Assert.IsTrue ( result.Count == 1 );
            Assert.IsTrue ( result.Contains ( "()" ) );
        }

        [TestMethod]
        public void AlgorithmP_4 () {
            // From the book
            ICollection<String> nestedPar4 = new HashSet<String> () {
                "()()()()", "()()(())", "()(())()", "()(()())",
                "()((()))", "(())()()", "(())(())", "(()())()",
                "(()()())", "(()(()))", "((()))()", "((())())",
                "((()()))", "(((())))"};
            ICollection<String> result = TreeGenerator.AlgorithmP ( 4 );

            Assert.IsTrue ( result.Count == nestedPar4.Count );
            Assert.IsTrue ( nestedPar4.All<String> ( e => result.Contains ( e ) ) );
        }
    }
}
