using BookStore.Business;
using BookStore.DataAcess.Results.Abstract;
using DataAcess.Concrete;
using Project1.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookStore
{
    // NOT: "Service1" sınıf adını kodda, svc'de ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    // NOT: Bu hizmeti test etmek üzere WCF Test İstemcisi'ni başlatmak için lütfen Çözüm Gezgini'nde Service1.svc'yi veya Service1.svc.cs'yi seçin ve hata ayıklamaya başlayın.
    public class BookService : IBookStore
    {
        private BookManager _bookManager;

        public BookService()
        {
            _bookManager = new BookManager(new efBookDal());
        }

        public ResultDataService<bool> AddBookToStock(Book book)
        {
            var result = _bookManager.AddBookToStock(book);
            return new ResultDataService<bool>(result.Success, result.Message,result.Success);
        }

        public ResultDataService<Book> CheckStock(int isbn)
        {
            var result = _bookManager.CheckStock(isbn);
            return new ResultDataService<Book>(result.Data, result.Message, result.Success);
        }

        public ResultDataService<List<Book>> CheckStocks(List<int> isbns)
        {
            var result = _bookManager.CheckStocks(isbns);
            return new ResultDataService<List<Book>>(result.Data, result.Message, result.Success);
        }

        public ResultDataService<List<Book>> GetAuthorBooks(Author author)
        {
            var result = _bookManager.GetAuthorBooks(author);
            return new ResultDataService<List<Book>>(result.Data, result.Message,result.Success);
        }

        public ResultDataService<List<Book>> GetBooks()
        {
            var result = _bookManager.GetBooks();
            return new ResultDataService<List<Book>>(result.Data, result.Message, result.Success);
        }

        public ResultDataService<List<Author>> GetAuthors()
        {
            var result = _bookManager.GetAuthors();             
            return new ResultDataService<List<Author>>(result.Data, result.Message, result.Success);
        }

        public ResultDataService<List<Book>> GetPublisherBooks(Publisher publisher)
        {
            var result = _bookManager.GetPublisherBooks(publisher);
            return new ResultDataService<List<Book>>(result.Data, result.Message, result.Success);
        }

        public ResultDataService<List<Publisher>> GetPublishers()
        {
            var result = _bookManager.GetPublishers();
            return new ResultDataService<List<Publisher>>(result.Data, result.Message, result.Success);
        }

        public ResultDataService<bool> IsValidISBN(int isbn)
        {
            var result = _bookManager.IsValidISBN(isbn);
            return new ResultDataService<bool>(result.Success, result.Message, result.Success);
        }
    }
}
