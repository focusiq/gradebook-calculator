using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTest
    {

        [Fact]
        public void StringsBehaveLikeValuTypes()
        {
            string name = "Ifeanyi";

            var upper = MakeUpperCase(name);

            Assert.Equal("Ifeanyi", name);
            Assert.Equal("IFEANYI", upper);
        
        
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(9, x);
        }

        private void SetInt(ref int x)
        {
            x = 9;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "Another Book");

            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");

            SetName(book1, "New Name");

            Assert.NotSame("Book 1", book1.Name);
        
        }

        private void SetName(Book book, string name)
        {
           book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
           
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);

        }




        Book GetBook(string name)
        {
            return new Book(name);
        }
    }


}
