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
        IEnumerable<String> nestedPar4String = new HashSet<String> () {
            "()()()()", "()()(())", "()(())()", "()(()())",
            "()((()))", "(())()()", "(())(())", "(()())()",
            "(()()())", "(()(()))", "((()))()", "((())())",
            "((()()))", "(((())))"
        };

        IEnumerable<Forest> all4;

        [TestInitialize]
        public void Init () {
            all4 = nestedPar4String.Select<String, Forest> ( s => new Parentheses ( s ) );
        }

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

        [TestMethod, Timeout(1000)]
        public void AlgorithmP_4 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmP ( 4 );

            Assert.IsTrue ( result.Count == all4.Count () );
            Assert.IsTrue ( all4.All<Forest> ( e => result.Contains ( e ) ) );
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

        [TestMethod, Timeout(1000)]
        public void AlgorithmN_4 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmN ( 4 );

            Assert.IsTrue ( result.Count == all4.Count () );
            Assert.IsTrue ( all4.All<Forest> ( e => result.Contains ( e ) ) );
        }
        
        [TestMethod]
        public void AlgorithmB_0 () {
            Assert.IsTrue ( ForestGenerator.AlgorithmB ( 0 ).Count == 0 );
        }

        [TestMethod, Timeout(100)]
        public void AlgorithmB_1 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmB ( 1 );
            Assert.IsTrue ( result.Count == 1 );
            Assert.IsTrue ( result.Contains ( new Parentheses ( "()" ) ) );
        }

        [TestMethod, Timeout(1000)]
        public void AlgorithmB_4 () {
            ICollection<Forest> result = ForestGenerator.AlgorithmB ( 4 );

            Assert.IsTrue ( result.Count == all4.Count () );
            Assert.IsTrue ( all4.All<Forest> ( e => result.Contains ( e ) ) );
        }
    }
}
