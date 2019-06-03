using System;
using Xunit;

namespace gradebook.tests
{
    public class gradebookTests
    {
        //testing GetStats() in the Statistics class       
        [Fact]
        public void BookStatisticsTest()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(90.0);
            book.AddGrade(75.0);
            book.AddGrade(25.3);

            //act
            var result = book.GetStats();

            //assert            
            Assert.Equal(63.43, result.average, 2);
            Assert.Equal(90.00, result.high, 2);
            Assert.Equal(25.30, result.low, 2);
        }
    }
}
