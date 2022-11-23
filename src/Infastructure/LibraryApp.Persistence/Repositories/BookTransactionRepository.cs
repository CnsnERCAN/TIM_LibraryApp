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
            var data = await dbContext.Set<BookTransaction>().Where(x => x.CheckInDate.Date <= date).ToListAsync() ?? throw new ArgumentNullException(nameof(date));
            foreach (BookTransaction item in data)
            {                
                if (item.CheckInDate.Date < DateTime.Now.Date)
                {
                    int eksikGun = (DateTime.Now.Date - item.CheckInDate.Date).Days;
                    if (eksikGun == 2)                    
                        item.CezaBedeli = 0.2;                    
                    if (eksikGun == 3)                    
                        item.CezaBedeli = 0.4;                                        
                    if(eksikGun > 3)
                    {                        
                        item.CezaBedeli = 0.4;
                        
                        for (int i = 4; i <= eksikGun; i++)
                        {
                            int fiboVal = getFiboValue(i);
                            item.CezaBedeli += (fiboVal * 0.2);
                        }
                    }
                }
            }
            return data;
        }

        private int getFiboValue(int eksikGun)
        {
            int val1 = 1;
            int val2 = 1;
            int val3 = 0;
            for (int i = 0; i <= eksikGun; i++)
            {
                val3 = val1 + val2;
                val1 = val2;
                val2 = val3;
            }

            return val3;
        }
    }
}
