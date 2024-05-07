using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Assignment1
{
    class Book  /* Note: The book class is complete. You may not change this class.*/
    {
        public string BookName { get; set; } //only book name alone is not unique
        public int Serial { get; set; } //Togather, book name and serial is unique
        public bool Status { get; set; } = false; //false means the book is available for renting

        public Book(string name, int serial)
        {
            BookName = name;
            Serial = serial;
        }
        public bool Available()
        {
            //returns true if a book is available
            if (!Status)
                return true;
            return false;
        }
        public bool Rent()
        {
            if (Status == false)
            {
                //A book can only be rented if it's rental status is false
                Status = true;
                return true;
            }
            return false; //otherwise, the book is not available.  
        }

        public bool Return()
        {
            if (Status == true)
            {
                //A book can be only returned if it is already rented.
                Status = false;
                return true;
            }
            else
            {
                // Status false means, the book is available in the store. (already returned)
                return false;
            }
        }
        public void BookInfo()
        {
            //Show name of the book, it's serial and rental status.
            Console.WriteLine("Book Name: {0}, Serial: {1}, Status: {2}", BookName, Serial, Status == true ? "Rented" : "Available");
        }
    }

    class Reader
    {
        //Fields/Properties are already provided to you.
        public string ReaderName { get; set; }
        public List<Book> readersBookList; //readers book list that will contain all books rented by that reader.
        public Reader(string name)
        {
            // The Reader Constructor is complete.
            ReaderName = name;
            readersBookList = new List<Book>();   //initialize empty book list 
        }
        public void RentABook(Book book)
        {
            //ToDo
            //user is allowed to rent maximum two books at a time.
            //issue error message, if users want to rent more than two books.
            /*
             * Example: 
             * if (readersBookList.Count >= 2)
             * {
             *   Display "You cannot rent more than two books!"  
             * }
             * else{
             *  //ToDo
             * Rent the book if available, display confirmation message.
             * if the book is already rented, display Sorry! the book is already rented message
             * }
             */

            if (readersBookList.Count >= 2)
            {
                Console.WriteLine("You cannot rent more than two books");
            }

          else
            {
                if (book.Available() == false)
                {
                   
                    Console.WriteLine("You have rented a book");
                }

                if(book.Rent() == true) { 
                
                    Console.WriteLine("Sorry! the {0} is already rented message", book.BookName); 
                }
                
   
            }





        }
        public void ReturnABook(Book book)
        {
            //ToDo
            //First check if the reader rented this book, 
            //if yes, change the book's status = false; meaning available
            //and remove the book for the readers book list.

            if (book.Return() == true)
            {
                book.Status = false;
                readersBookList.Remove(book);
            }

        }
        public void ReaderInfo()
        {
            //This method is complete.
            //show reader's name and the list of books rented by the reader.
            //If no books are rented by the reader yet, display "No books rented yet!".

            Console.WriteLine("Reader {0} rented the following books:", ReaderName);
            if (readersBookList.Count == 0)
            {
                Console.WriteLine("No books rented yet!");
                return;
            }
            foreach (var book in readersBookList)
            {
                book.BookInfo();
            }
        }
    }
    class BookStore
    {
        //Required fileds are already provided to you.

        public List<Book> BookStoreBooksList;
        public List<Reader> BookStoreReadersList;
        public BookStore()
        {
            //Constructor method is complete.
            BookStoreBooksList = new List<Book>();  //initially bookstore has no books
            BookStoreReadersList = new List<Reader>(); //initially bookstore has no readers
        }
        public void AddAReader(string name)
        {
            //This method is complete
            //add a new reader to the bookstoreReadersList.
            Reader reader = new Reader(name);
            BookStoreReadersList.Add(reader);
          
        }
        public void RemoveAReader(string name)
        {
            //ToDo
            //Check if the reader is registered to the bookstore, if not generate error message
            //For a registered/existing reader, in order to remove a reader,
            //first, return all books (if any) rented by that reader and then remove the reader from BookStoreReadersList.


            foreach(var reader in BookStoreReadersList) { 
            
                if (reader.ReaderName == name)

                {

                    reader.ReaderInfo();
                  

                    Console.WriteLine("Reader {0} successfully removed from bookstore.", name);

                }


               
            }

           
        

        }


        public void AddABook(string name, int serial)
        {
            //ToDo
            // add a book object to the BookStoreBooksList with BookName and Serial.

            Book book = new Book(name, serial);
            BookStoreBooksList.Add(book);
            

        }
        public void RemoveABook(string name, int serial)
        {
            //ToDo
            //find the book with correct name and serial from BookStoreBooksList.
            //In order to remove a book from book store, only allow if the book's status==false
            //meaning the book is 'available' to the bookstore.
            //Otherwise, issue an error message because the book is already rented by some readers!


           foreach (Book book in BookStoreBooksList)
            {
                if (book.BookName == name && book.Serial == serial)
                {

                  if ( book.Available() == true)
                    {
                   
                        Console.WriteLine("The book: {0} : {1}, is successfully removed from the bookstore.", name, serial);
                    }
                    else
                    {

                        Console.WriteLine("Sorry! {0}  is already rented. System cannot remove a rented book!", name);
                    }
                }
              
            }


            



        }
        public void RentABook(string readerName, string bookName)
        {
            //ToDo
            //Find the reader from the BookStoreReadersList
            //If the reader is not registered to bookstore, display "you are not a registered reader of this bookstore"
            //Otherwise
            //A book can be rented, if it is available to the store and not already rented to somone else!
            //Display Sorry the book is not Available for renting; if already rented by another reader.


          Reader reader.find(i => i.ReaderName == readerName);


            if (!reader)
            {
                console.WriteLine("you are not a registered reader of this bookstore");

            }
            else
            {

            }


                

            }


        }


        public void ReturnABook(string readerName, string bookName, int serial)
        {
            //ToDo
            //A book can be returned by a reader, if he/she actually rented the book.
            //Find the reader from BookStoreReadersList
            //Find the book with correct serial from from reader's personal book list
            //Return the book by calling 'ReturnABook' method of the Reader class.

            foreach (Reader reader in BookStoreReadersList)
            {

                readerName = reader.ReaderName;

                foreach (Book book in BookStoreBooksList)
                {

                    bookName = book.BookName;
                    serial = book.Serial;

                    ReturnABook(readerName, bookName, serial);
                }
         

            }

                 


        }

        public void ShowBookInformation()
        {
            //ToDo
            //This method is complete for your understanding.
            //Show all books that are available to the bookstore (if any).
            //i.e. call BookInfo method for every book of the BookStoreBooksList

            foreach(var book in BookStoreBooksList)
            {
                Console.WriteLine("The bookstore has the following books available: ");
                
                book.BookInfo();
            }
        }

        public void ShowReaderInformation()
        {
            //This method is complete
            //Show all readers that are added to the bookstore (if any).
            //i.e. call ReaderInfo method for every reader of the BookStoreReadersList
            if (BookStoreReadersList.Count == 0)
            {
                Console.WriteLine("The bookstore currently have no readers.");
                return;
            }
            Console.WriteLine("The bookstore has the following readers:");
            foreach (var reader in BookStoreReadersList)
            {
                reader.ReaderInfo();
            }
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*You should not change the code in the Main Method. */

            BookStore bs = new BookStore();
            bs.AddAReader("Mahbub Murshed");
            bs.AddAReader("David Alwright");
            bs.AddAReader("Susan Harper");
            bs.AddABook("Object Oriented Programming", 1);
            bs.AddABook("Object Oriented Programming", 2);
            bs.AddABook("Object Oriented Programming", 3);
            bs.AddABook("Programming Fundamentals", 1);
            bs.AddABook("Programming Fundamentals", 2);
            bs.AddABook("Let us C#", 1);
            bs.AddABook("Programming is Fun", 1);
            bs.AddABook("Life is Beautiful", 1);
            bs.AddABook("Let's Talk About the Logic", 1);
            bs.AddABook("How to ace a job interview", 1);

            bs.ShowBookInformation();
            bs.ShowReaderInformation();

            bs.RentABook("Salma Hayek", "Object Oriented Programming");

            bs.RentABook("Mahbub Murshed", "Object Oriented Programming");
            bs.RentABook("Mahbub Murshed", "How to ace a job interview");
            bs.RentABook("Mahbub Murshed", "Life is Beautiful");

            Console.WriteLine();

            bs.RentABook("David Alwright", "Object Oriented Programming");
            bs.RentABook("David Alwright", "Programming Fundamentals");
            Console.WriteLine();

            bs.RentABook("Susan Harper", "Let's Talk About the Logic");
            bs.RentABook("Susan Harper", "How to ace a job interview");
            Console.WriteLine();

            bs.ShowBookInformation();
            bs.ShowReaderInformation();


            bs.ReturnABook("Mahbub Murshed", "Object Oriented Programming", 1);
            bs.RentABook("Mahbub Murshed", "Life is Beautiful");
            Console.WriteLine();

            bs.ReturnABook("Mahbub Murshed", "Programming Fundamentals", 1);

            bs.RemoveABook("Let us C#", 1);
            bs.RemoveABook("Let's Talk About the Logic", 1);

            bs.ShowReaderInformation();
            bs.RemoveAReader("Mahbub Murshed");


            bs.ShowBookInformation();
            bs.ShowReaderInformation();
            Console.Read();

        }

    }
}



/*
Once Executed, Your program will have the following output:

The bookstore has the following books available:
Book Name: Object Oriented Programming, Serial: 1, Status: Available
Book Name: Object Oriented Programming, Serial: 2, Status: Available
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamentals, Serial: 1, Status: Available
Book Name: Programming Fundamentals, Serial: 2, Status: Available
Book Name: Let us C#, Serial: 1, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available
Book Name: Let's Talk About the Logic, Serial: 1, Status: Available
Book Name: How to ace a job interview, Serial: 1, Status: Available

The bookstore has the following readers:
Reader Mahbub Murshed rented the following books:
No books rented yet!
Reader David Alwright rented the following books:
No books rented yet!
Reader Susan Harper rented the following books:
No books rented yet!

Salma Hayek, you are not a registered reader of this bookstore!

Book: 'Object Oriented Programming' successfully rented by Mahbub Murshed.
Book: 'How to ace a job interview' successfully rented by Mahbub Murshed.
Sorry! Mahbub Murshed, You cannot rent more than two books!

Book: 'Object Oriented Programming' successfully rented by David Alwright.
Book: 'Programming Fundamentals' successfully rented by David Alwright.

Book: 'Let's Talk About the Logic' successfully rented by Susan Harper.
Sorry Susan Harper, The book 'How to ace a job interview' is not Available for renting.

The bookstore has the following books available:
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamentals, Serial: 2, Status: Available
Book Name: Let us C#, Serial: 1, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available

The bookstore has the following readers:
Reader Mahbub Murshed rented the following books:
Book Name: Object Oriented Programming, Serial: 1, Status: Rented
Book Name: How to ace a job interview, Serial: 1, Status: Rented
Reader David Alwright rented the following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamentals, Serial: 1, Status: Rented
Reader Susan Harper rented the following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented

Book: 'Object Oriented Programming', Serial: 1 successfully returned by Mahbub Murshed.
Book: 'Life is Beautiful' successfully rented by Mahbub Murshed.

Return Error! Mahbub Murshed, you have not rented Programming Fundamentals, Serial: 1

The book: Let us C#,Serial: 1, is successfully removed from the bookstore.
Sorry! 'Let's Talk About the Logic' is already rented. System cannot remove a rented book!

The bookstore has the following readers:
Reader Mahbub Murshed rented the following books:
Book Name: How to ace a job interview, Serial: 1, Status: Rented
Book Name: Life is Beautiful, Serial: 1, Status: Rented
Reader David Alwright rented the following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamentals, Serial: 1, Status: Rented
Reader Susan Harper rented the following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented

Returning books rented by Mahbub Murshed:
Book: 'How to ace a job interview', Serial: 1 successfully returned by Mahbub Murshed.
Book: 'Life is Beautiful', Serial: 1 successfully returned by Mahbub Murshed.
Reader Mahbub Murshed successfully removed from bookstore.

The bookstore has the following books available:
Book Name: Object Oriented Programming, Serial: 1, Status: Available
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamentals, Serial: 2, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available
Book Name: How to ace a job interview, Serial: 1, Status: Available

The bookstore has the following readers:
Reader David Alwright rented the following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamentals, Serial: 1, Status: Rented
Reader Susan Harper rented the following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented

 */

