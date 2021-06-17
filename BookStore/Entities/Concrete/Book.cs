using DataAcess.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Concrete
{
    public class Book : IEntity
    {
        public int Isbn { get; set; }
        public bool IsValid { get; set; }
        public Author Autor { get; set; }
        public Publisher Publisher { get; set; }
        public  Format Format { get; set; }
        public DateTime RelaseDate { get; set; }
        public int Version { get; set; }
        public string Preface { get; set; }      
        public int Quantity_Left { get; set; }
        public int WareLocation { get; set; }

        public DateTime NextStoctDate { get; set; }
    }

    public enum Format
    {
        Digital,
        Print,
        Both
    }
}
