using LibraryApp.Application.Dto;
using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Domain.Entites;
using LibraryApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories
{
    public class BookTransactionRepository : GenericRepository<BookTransaction>, IBookTransactionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookTransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BookTransaction> AddTransactionAsync(BookTransaction entity)
        {
            List<DateTime> publicHodidays = await dbContext.Holidays.Select(x => x.Holiday.Date).ToListAsync();
            DateTime checkInDate = entity.CheckInDate;
            entity.CheckInDate = SetCheckInDate(publicHodidays, checkInDate.Date);

            await dbContext.Set<BookTransaction>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        private DateTime SetCheckInDate(List<DateTime> publicHodidays, DateTime checkInDate)
        {
            bool flag = true;
            do
            {
                if (publicHodidays.Contains(checkInDate.Date))               
                    checkInDate = Convert.ToDateTime(checkInDate).AddDays(1);                
                flag = publicHodidays.Contains(checkInDate.Date);
            } while (flag);
            return Convert.ToDateTime(checkInDate);            
        }

        public async Task<List<BookTransaction>> GetLast3DaysAsync(DateTime date)
        {
            date = date.AddDays(3); //CE: Günümüz tarihinden 3 sonrasını
            return await dbContext.Set<BookTransaction>().Where(x => x.CheckInDate.Date <= date).ToListAsync() ?? throw new ArgumentNullException(nameof(date)); ;
        }
    }
}
