using System;
using System.Collections.Generic;
using System.Linq;
using HW02.HashTable;
using HW02.ImmutableList;
using Xunit;


namespace UnitTests.ImmutableListTest
{
    public class Tests
    {

        [Fact]
        public void ContentIsSetProperly()
        {
            // Arrange 
            var immutableList = new ImmutableList<int>();

            // Act
            var data = immutableList.Add(3).Add(4).Insert(0, 8);
        
            // Assert 
            Assert.Equal(data.ToList(), new List<int> { 8, 3, 4 });
        }

    }
}
