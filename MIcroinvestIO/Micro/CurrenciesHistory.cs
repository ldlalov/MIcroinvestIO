using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class CurrenciesHistory
{
    public int Id { get; set; }

    public int? CurrencyId { get; set; }

    public double? ExchangeRate { get; set; }

    public DateTime? Date { get; set; }

    public int? UserId { get; set; }
}
