using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class UsersSecurity
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ControlName { get; set; }

    public int? State { get; set; }
}
