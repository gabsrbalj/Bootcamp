using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementating.Model;
using Implementating.Model.Common;

namespace Implementating.Repository.Common
{
    public interface IUnreturnedBooksRepository
    {
        Task<List<UnreturnedBooks>> GetAllBookInfoAsync(int id);
        Task<List<UnreturnedBooks>> UpdateNewUserAsync(UnreturnedBooks unreturnedbooks);
        Task<List<UnreturnedBooks>> DeleteBookAsync(int id);

    }
}
