using Implementating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementating.Repository;
using System.Net.Http;
using Implementating.Service.Common;

namespace Implementating.Service
{
    public class UnreturnedBooksService : IUnreturnedBooksService
    {
        public async Task<List<UnreturnedBooks>> GetAllBookInfoAsync(int id)
        {
            UnreturnedBooksRepository bookobj = new UnreturnedBooksRepository();
            return await bookobj.GetAllBookInfoAsync(id);
        }

        public async Task<List<UnreturnedBooks>> InsertNewUserAsync(UnreturnedBooks unreturnedbooks)
        {
            UnreturnedBooksRepository bookobj = new UnreturnedBooksRepository();
            return await bookobj.InsertNewUserAsync(unreturnedbooks);
        }

        public async Task<List<UnreturnedBooks>> DeleteBookAsync(int id)
        {
            UnreturnedBooksRepository bookobj = new UnreturnedBooksRepository();
            return await bookobj.DeleteBookAsync(id);
        }

    }
}
