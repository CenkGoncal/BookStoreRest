using BookStore.DataAcess.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DataAcess.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}