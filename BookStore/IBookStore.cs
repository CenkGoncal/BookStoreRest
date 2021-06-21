﻿using BookStore.DataAcess.Results.Abstract;
using DataAcess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookStore
{
    // NOT: "IService1" arabirim adını kodda ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    [ServiceContract]
    public interface IBookStore
    {

        [OperationContract]
        [WebInvoke(Method ="GET",RequestFormat =WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<Book> CheckStock(int isbn);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<List<Book>> CheckStocks(List<int> isbns);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<List<Author>> GetAuthors();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<List<Book>> GetBooks();


        [OperationContract]
        [WebInvoke(Method ="POST",RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<List<Book>> GetAuthorBooks(Author author);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<List<Publisher>> GetPublishers();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<List<Book>> GetPublisherBooks(Publisher publisher);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<bool> IsValidISBN(int isbn);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultDataService<bool> AddBookToStock(Book book);

        // TODO: Hizmet işlemlerinizi buraya ekleyin
    }


    // Hizmet işlemlerine bileşik türler eklemek için, aşağıdaki örnekte gösterildiği şekilde bir veri sözleşmesi kullanın.
    [DataContract]
    public class ResultDataService<T>
    {
        private T dataResult;
        private string message;
        private bool state;

        public ResultDataService(T dataResult, string message,bool state)
        {
            this.dataResult = dataResult;
            this.message = message;
            this.state = state;
        }

        [DataMember]
        public T DataResult
        {
            get { return dataResult; }
            set { dataResult = value; }
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public bool IsSuccess
        {
            get { return state; }
            set { state = value; }
        }

    }


    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
