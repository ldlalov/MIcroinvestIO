using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessPlan
{
    public int FitnessPlanId { get; set; }

    public int? PlanType { get; set; }

    public string PlanName { get; set; } = null!;

    public bool Deleted { get; set; }

    public bool IsBusy { get; set; }

    public virtual ICollection<FitnessPlanTiming> FitnessPlanTimings { get; set; } = new List<FitnessPlanTiming>();

    public virtual ICollection<FitnessService> FitnessServices { get; set; } = new List<FitnessService>();
}
