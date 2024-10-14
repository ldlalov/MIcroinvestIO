using MIcroinvestIO.Micro;

namespace MIcroinvestIO.Services.Interfaces
{
    public interface ICashBookService
    {
        Task<List<CashBook>> AllCashBookRecords();
        Task<List<CashBook>> FiltheredRecords(DateTime? startDate, DateTime? endDate);
    }
}
