using MIcroinvestIO.Micro;
using MIcroinvestIO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MIcroinvestIO.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly MultiContext context;
        private List<Payment> records;
        public PaymentService(MultiContext context)
        {
            this.context = context;
        }

        public async Task<List<Payment>> Paid()
        {
            records = await context.Payments
                .Where(p => p.Mode == 1)
                .OrderBy(p => p.Acct)
                .ToListAsync();
            return records;
        }

        public async Task<List<Payment>> Unpaid()
        {
            var result = await context.Payments
                .Where(p =>  context.Payments
                .Count(inner => inner.Acct == p.Acct) == 1 && p.Qtty > 0)  // Subquery to find duplicates
                .OrderBy(p => p.Acct)
                .ToListAsync();
            return result;
        }
    }
}
