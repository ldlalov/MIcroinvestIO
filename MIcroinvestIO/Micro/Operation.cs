using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Operation
{
    public int Id { get; set; }

    public int? OperType { get; set; }

    public int? Acct { get; set; }

    public int? GoodId { get; set; }

    public int? PartnerId { get; set; }

    public int? ObjectId { get; set; }

    public int? OperatorId { get; set; }

    public double? Qtty { get; set; }

    public int? Sign { get; set; }

    public double? PriceIn { get; set; }

    public double? PriceOut { get; set; }

    public double? Vatin { get; set; }

    public double? Vatout { get; set; }

    public double? Discount { get; set; }

    public int? CurrencyId { get; set; }

    public double? CurrencyRate { get; set; }

    public DateTime? Date { get; set; }

    public string? Lot { get; set; }

    public int? LotId { get; set; }

    public string? Note { get; set; }

    public int? SrcDocId { get; set; }

    public int? UserId { get; set; }

    public DateTime? UserRealTime { get; set; }
}
