using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class PaymentType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PaymentMethod { get; set; }
}
