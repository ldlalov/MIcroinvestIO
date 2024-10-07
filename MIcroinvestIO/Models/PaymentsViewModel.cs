using MIcroinvestIO.Micro;

namespace MIcroinvestIO.Models
{
    public class PaymentsViewModel
    {
        public int? Acct { get; set; }
        public DateTime? DateTime { get; set; }
        public Double? Qtty { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
        public int ObjectId { get; set; }
        public MIcroinvestIO.Micro.Object Object { get; set; }
    }
}
