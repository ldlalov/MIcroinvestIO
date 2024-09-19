using MIcroinvestIO.Micro;
using MIcroinvestIO.Models;
using MIcroinvestIO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MIcroinvestIO.Services
{
    public class CashBookService : ICashBookService
    {
        private readonly MultiContext context;
        private List<CashBook> records;
        public CashBookService(MultiContext context)
        {
            this.context = context;
        }
        public async Task<List<CashBook>> AllCashBookRecords()
        {
            records = await context.CashBooks.ToListAsync();
            return records;
        }

        public async Task<List<CashBook>> FiltheredRecords(DateTime? startDate, DateTime? endDate)
        {
            records = await context.CashBooks.Where(x => x.Date >= startDate && x.Date <= endDate).ToListAsync();
            return records;
        }
    }
}
