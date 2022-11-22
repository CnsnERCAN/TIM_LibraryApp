using LibraryApp.Application.Dto;
using LibraryApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Repositories
{
    public interface IBookTransactionRepository : IGenericRepositoryAsync<BookTransaction>
    {
        Task<BookTransaction> GetByBookNameAsync(string name);
        Task<List<BookTransaction>> GetLast3DaysAsync(DateTime date);
        Task<BookTransaction> AddTransactionAsync(BookTransaction entity);
    }
}
