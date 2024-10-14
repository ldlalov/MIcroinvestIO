using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessDuration
{
    public int FitnessDurationId { get; set; }

    public int YearDuration { get; set; }

    public int MonthDuration { get; set; }

    public int WeekDuration { get; set; }

    public int DayDuration { get; set; }

    public bool Infinity { get; set; }

    public virtual ICollection<FitnessService> FitnessServices { get; set; } = new List<FitnessService>();
}
