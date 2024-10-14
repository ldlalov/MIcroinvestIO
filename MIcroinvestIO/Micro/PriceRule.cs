using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class PriceRule
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Formula { get; set; }

    public int? Enabled { get; set; }

    public int? Priority { get; set; }
}
