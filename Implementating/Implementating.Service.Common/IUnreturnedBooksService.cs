using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementating.Model;
using Implementating.Repository;

namespace Implementating.Service.Common
{
    public interface IUnreturnedBooksService
    {
        Task<List<UnreturnedBooks>> GetAllBookInfoAsync(int id);

        Task<List<UnreturnedBooks>> UpdateNewUserAsync(UnreturnedBooks unreturnedbooks);

        Task<List<UnreturnedBooks>> DeleteBookAsync(int id);
    }
}
