using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Store
{
    public int Id { get; set; }

    public int? ObjectId { get; set; }

    public int? GoodId { get; set; }

    public double? Qtty { get; set; }

    public double? Price { get; set; }

    public string? Lot { get; set; }

    public int? LotId { get; set; }

    public int? LotOrder { get; set; }
}
