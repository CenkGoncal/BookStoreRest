using BookStore.DataAcess.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DataAcess.Results.Concrete
{
    
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}