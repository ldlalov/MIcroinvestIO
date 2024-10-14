using MIcroinvestIO.Micro;

namespace MIcroinvestIO.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<Payment>> Paid();
        Task<List<Payment>> Unpaid();
    }
}
