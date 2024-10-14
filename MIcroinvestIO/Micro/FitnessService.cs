using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessService
{
    public int FitnessServiceId { get; set; }

    public int GoodId { get; set; }

    public int FitnessDurationId { get; set; }

    public int VisitsAllowed { get; set; }

    public float ServiceDuration { get; set; }

    public int InstructorsAllowed { get; set; }

    public int FitnessPlanId { get; set; }

    public bool Deleted { get; set; }

    public int DailyTrainsAllowed { get; set; }

    public int ServiceType { get; set; }

    public virtual FitnessDuration FitnessDuration { get; set; } = null!;

    public virtual FitnessPlan FitnessPlan { get; set; } = null!;

    public virtual ICollection<FitnessVisit> FitnessVisits { get; set; } = new List<FitnessVisit>();
}
