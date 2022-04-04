using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementating.Model.Common;

namespace Implementating.Model
{
    public class UnreturnedBooks : IUnreturnedBooks
    {
        public string AuthorsName { get; set; }

        public string BookName { get; set; }

        public int BookID { get; set; }

       
    }
}
