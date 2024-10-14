using MIcroinvestIO.Micro;

namespace MIcroinvestIO.Models
{
    public class OperationDetailsViewModel
    {
        public int? Acct { get; set; }
        public string? OperType { get; set; }
        public string? Object { get; set; }
        public double? Sum { get; set; }
        public List<Good> goods { get; set; }
    }
}
