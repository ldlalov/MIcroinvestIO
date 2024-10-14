using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Lot
{
    public int Id { get; set; }

    public string? SerialNo { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? ProductionDate { get; set; }

    public string? Location { get; set; }
}
