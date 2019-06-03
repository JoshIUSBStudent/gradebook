using System;
using Xunit;

namespace gradebook.tests
{
    public class typeTests
    {
        //test that objects created are different
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
          
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        //testing that the reference is the same when an object 
        //is passed to another variable
        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        
        //helper method used in tests above
        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
