using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessPlanTiming
{
    public int FitnessPlanTimingId { get; set; }

    public int FitnessPlanId { get; set; }

    public int FitnessTimingId { get; set; }

    public virtual FitnessPlan FitnessPlan { get; set; } = null!;
}
