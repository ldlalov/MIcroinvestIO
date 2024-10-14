using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessTiming
{
    public int FitnessTimingId { get; set; }

    public int Days { get; set; }

    public DateTime TimeFrom { get; set; }

    public DateTime TimeTo { get; set; }
}
