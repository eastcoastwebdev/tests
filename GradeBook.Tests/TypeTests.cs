using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logmessage);
    public delegate int MultiplyNumbersDelegate(int number1, int number2);
   
    
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void MultiplyingRandomNumbersDelegate()
        {
            MultiplyNumbersDelegate  numbersoutput = Numbers;
            numbersoutput += Numbers;
            numbersoutput += NumbersCount;
            var result = numbersoutput(15, 25);
            
            Assert.Equal(3, count);
        }

        int NumbersCount(int number1, int number2)
        {
            count++;
            var x = 15;
            var y = 25;
            return x * y;
        }
        
        int Numbers(int number1, int number2)
        {
            count++;
            var x = 15;
            var y = 25;
            return x * y;
        }
        

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate  log;

            log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }


        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(55, x);
            
        }

        private void SetInt(ref int z)
        {
            z = 55;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange- data to be acted on
         var book1 = GetBook("Book 1");
         GetBookSetName(ref book1, "New Name");

         Assert.Equal("New Name", book1._name);
        
        }

        [Fact]
        public void StringsActLikeValueTypes()
        {
             string name = "Chris";
             var upper = MakeUpperCase(name);
             Assert.Equal("Chris", name);
             Assert.Equal("CHRIS", upper);//what you're expecting, vs what your code returns
        }

        private string MakeUpperCase(string parameter)
        {
           return parameter.ToUpper();
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

          [Fact]
        public void CSharpPassByValue()
        {
            //arrange- data to be acted on
         var book1 = GetBook("Book 1");
         GetBookSetName(book1, "book 1");

         Assert.Equal("Book 1", book1._name);
        
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

         [Fact]
        public void CanSetNameByReference()
        {
            //arrange- data to be acted on
         var book1 = GetBook("Book 1");
         SetName(book1, "Book 1");

         Assert.Equal("Book 1", book1._name);
        
        }

        private void SetName(Book book, string name)
        {
            book._name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            //arrange- data to be acted on
         var book1 = GetBook("Book 1");
         var book2 = GetBook("Book 2");

         Assert.Equal("Book 1", book1._name);
         Assert.Equal("Book 2", book2._name);
         Assert.NotSame(book1, book2);
        }

         [Fact]
        public void VarsReferenceSameObject()
        {
            //arrange- data to be acted on
         var book1 = GetBook("Book 1");
         var book2 = book1;

         Assert.Same(book1, book2);
         Assert.True(ReferenceEquals(book1, book2));
         }

         Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
