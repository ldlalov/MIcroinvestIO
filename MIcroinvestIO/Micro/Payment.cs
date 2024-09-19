using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Payment
{
    public int Id { get; set; }

    public int? Acct { get; set; }

    public int? OperType { get; set; }

    public int? PartnerId { get; set; }

    public double? Qtty { get; set; }

    public int? Mode { get; set; }

    public int? Sign { get; set; }

    public DateTime? Date { get; set; }

    public int? UserId { get; set; }

    public int? ObjectId { get; set; }

    public DateTime? UserRealTime { get; set; }

    public int? Type { get; set; }

    public string? TransactionNumber { get; set; }

    public DateTime? EndDate { get; set; }
}
