using DataAcess.Concrete;
using Project1.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;


namespace Project1.Concrete.EntityFramework
{
    public class efBookDal : IBookDal
    {
        List<Book> _booklist;
        public efBookDal()
        {
            if(_booklist == null)
                CreateFaker(100);
        }


        public List<Book> GetBooks()
        {
            var a = _booklist;
            return a;
        }
        public bool AddBookToStock(Book book)
        {
            var nbook = _booklist.FirstOrDefault(w =>w.Isbn == book.Isbn);
            if (nbook != null)
            {
                nbook.Quantity_Left++;                
            }

            return true;
        }

        public Book CheckStock(int isbn)
        {
            var nbook = _booklist.FirstOrDefault(w => w.IsValid == true && w.Isbn == isbn);

            return nbook;
        }

        public List<Book> CheckStock(List<int> isbns)
        {
            var nbooks = _booklist.Where(w => w.IsValid == true && isbns.Contains(w.Isbn)).ToList();

            return nbooks;
        }

        public List<Book> GetAuthorBooks(Author author)
        {
            return _booklist.Where(w => w.Autor.Id == author.Id).ToList();
        }

        public List<Author> GetAuthors()
        {
            return _booklist.Select(w => w.Autor).Distinct().ToList();
        }

        public List<Publisher> GetPublishers()
        {
            return _booklist.Select(w => w.Publisher).Distinct().ToList();
        }

        public List<Book> GetPulisherBooks(Publisher publisher)
        {
            return _booklist.Where(w => w.Publisher.Id == publisher.Id).ToList();
        }

        public bool IsValidISBN(int isbn)
        {
            return _booklist.Any(w => w.IsValid == true && w.Isbn == isbn);
        }

        private void CreateFaker(int count)
        {
            int AutorId = 1;
            var autorfaker = new Faker<Author>()
                .RuleFor(i => i.Id, i => AutorId++)
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.SurName, i => i.Person.LastName)
                .RuleFor(i => i.Age, i => i.Random.Number(18, 65));

            int Publisher = 1;
            var publisherfaker = new Faker<Publisher>()
                .RuleFor(i => i.Id, i => Publisher++)
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.SurName, i => i.Person.LastName)
                .RuleFor(i => i.Age, i => i.Random.Number(18, 65));


            int Isbn = 1;
            var bookfaker = new Faker<Book>()
                .RuleFor(i => i.Isbn, i => Isbn++)
                .RuleFor(i => i.IsValid, i => i.Random.Bool())
                .RuleFor(i => i.Autor, autorfaker.Generate(1).First())
                .RuleFor(i => i.Publisher, publisherfaker.Generate(1).First())
                .RuleFor(i => i.Format, i => i.PickRandom<Format>())
                .RuleFor(i => i.RelaseDate, i => i.Date.Recent())
                .RuleFor(i => i.Version, i => i.Random.Number(1, 10))
                .RuleFor(i => i.Preface, i => i.Lorem.Sentence())
                .RuleFor(i => i.Quantity_Left, i => i.Random.Int(0, 100))
                .RuleFor(i => i.WareLocation, i => i.Random.Int(001, 999))
                .RuleFor(i => i.RelaseDate, i => i.Date.Future());


            _booklist = bookfaker.Generate(count);
        }
    }
}
