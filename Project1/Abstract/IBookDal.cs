using DataAcess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Abstract
{
    public interface IBookDal
    {
        Book CheckStock(int isbn);
        bool AddBookToStock(Book book);

        List<Book> CheckStock(List<int> isbns);

        bool IsValidISBN(int isbn);

        List<Author> GetAuthors();

        List<Book> GetAuthorBooks(Author author);

        List<Publisher> GetPublishers();

        List<Book> GetPulisherBooks(Publisher publisher);

    }
}
