using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class CashBook
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Desc { get; set; }

    public int? OperType { get; set; }

    public int? Sign { get; set; }

    public double? Profit { get; set; }

    public int? UserId { get; set; }

    public DateTime? UserRealtime { get; set; }

    public int? ObjectId { get; set; }
}
