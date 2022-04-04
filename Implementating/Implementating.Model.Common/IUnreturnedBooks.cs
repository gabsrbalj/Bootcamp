using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementating.Model.Common
{
    public interface IUnreturnedBooks
    {
        string AuthorsName { get; set; }

        string BookName { get; set; }

        int BookID { get; set; }
    }
}
