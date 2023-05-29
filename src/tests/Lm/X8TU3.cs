using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using SparseMatrix;

namespace Tests.SparseMatrixTests
{   
    [TestFixture]
    public class SparseMatrixTests
    {
        [Test]
        public void Test()
        {
            var table = new SparseMatrix.SparseMatrix();
            table[0, 0, 0] = 1;
            Assert.True(table[0, 0, 0] == 1);
            table[22335, 346326236, 23453553] = 354236;
            Assert.True(table[22335, 346326236, 23453553] == 354236);
            table[22335, 346326236, 23453553] = 0;
            Assert.True(table[22335, 346326236, 23453553] == 0);
            var rng = new Random();
            for (var it = 0; it < 1000; ++it)
            {
                var i = rng.Next(0, 1000000);
                var j = rng.Next(0, 1000000);
                var k = rng.Next(0, 1000000);
                table[i, j, k] = 1;
            }

            var list = table.ToList();
            Assert.True(list.Count == 1001);
        }
    }
}