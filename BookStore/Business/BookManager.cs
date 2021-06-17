using BookStore.DataAcess.Results.Abstract;
using BookStore.DataAcess.Results.Concrete;
using DataAcess.Concrete;
using Project1.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Business
{
    public class BookManager 
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookdal)
        {
            _bookDal = bookdal;
        }
        
        public IResult AddBookToStock(Book book)
        {
            if(_bookDal.IsValidISBN(book.Isbn))
            {
                _bookDal.AddBookToStock(book);

                return new SuccessResult("Book Added to Stock");
            }
            else
            {
                return new ErrorResult("Book is not valid");
            }
        }

        public IDataResult<Book> CheckStock(int isbn)
        {
            SuccessDataResult<Book> success = new SuccessDataResult<Book>(_bookDal.CheckStock(isbn));            
            return success;
        }

        public IDataResult<List<Book>> CheckStocks(List<int> isbns)
        {
            SuccessDataResult<List<Book>> success = new SuccessDataResult<List<Book>>(_bookDal.CheckStock(isbns));
            return success;
        }

        public IDataResult<List<Author>> GetAuthors()
        {
            return new SuccessDataResult<List<Author>>(_bookDal.GetAuthors(), "Listed Autors");
        }

        public IDataResult<List<Book>> GetAuthorBooks(Author author)
        {
            var booklist = _bookDal.GetAuthorBooks(author);

            if (booklist.Count > 0)
                return new SuccessDataResult<List<Book>>(booklist, "Listed Autor of Book");
            else
                return new ErrorDataResult<List<Book>>("There is not book by Autor");
        }

        public IDataResult<List<Publisher>> GetPublishers()
        {
            return new SuccessDataResult<List<Publisher>>(_bookDal.GetPublishers(), "Listed Publishers");
        }

        public IDataResult<List<Book>> GetPublisherBooks(Publisher publisher)
        {
            var booklist = _bookDal.GetPulisherBooks(publisher);

            if (booklist != null)
                return new SuccessDataResult<List<Book>>(booklist, "Listed publisher of Book");
            else
                return new ErrorDataResult<List<Book>>("There is not book by publisher");
        } 

        public IDataResult<List<Book>> GetBooks()
        {
            var booklist = _bookDal.GetBooks();

            if (booklist.Count > 0)
                return new SuccessDataResult<List<Book>>(booklist, "Listed of Book");
            else
                return new ErrorDataResult<List<Book>>("There is not book");
        }

        public IResult IsValidISBN(int isbn)
        {
            if (_bookDal.IsValidISBN(isbn))
                return new SuccessResult("Book is valid");
            else
                return new ErrorResult("Book is not valid");
        }
    }
}