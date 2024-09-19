using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class User
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Name2 { get; set; }

    public int? IsVeryUsed { get; set; }

    public int? GroupId { get; set; }

    public string? Password { get; set; }

    public int? UserLevel { get; set; }

    public int? Deleted { get; set; }

    public string? CardNumber { get; set; }
}
