using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class ApplicationLog
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public int? UserId { get; set; }

    public DateTime? UserRealtime { get; set; }

    public string? MessageSource { get; set; }
}
