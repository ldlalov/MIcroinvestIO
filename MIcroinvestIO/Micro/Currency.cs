using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Currency
{
    public int Id { get; set; }

    public string? Currency1 { get; set; }

    public string? Description { get; set; }

    public double? ExchangeRate { get; set; }

    public int? Deleted { get; set; }
}
