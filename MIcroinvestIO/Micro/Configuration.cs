using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Configuration
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    public int? UserId { get; set; }
}
