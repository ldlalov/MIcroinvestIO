using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Transformation
{
    public int Id { get; set; }

    public int RootOperType { get; set; }

    public int RootAcct { get; set; }

    public int FromOperType { get; set; }

    public int FromAcct { get; set; }

    public int ToOperType { get; set; }

    public int ToAcct { get; set; }

    public int UserId { get; set; }

    public DateTime? UserRealTime { get; set; }
}
