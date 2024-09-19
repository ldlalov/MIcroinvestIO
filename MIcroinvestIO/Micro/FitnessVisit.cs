using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessVisit
{
    public int FitnessVisitId { get; set; }

    public int PartnerId { get; set; }

    public int FitnessServiceId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int VisitType { get; set; }

    public int ServiceCount { get; set; }

    public int VisitsUsed { get; set; }

    public int InstructorsUsed { get; set; }

    public int ActiveUserId { get; set; }

    public bool Deleted { get; set; }

    public DateTime? UserRealTime { get; set; }

    public virtual FitnessService FitnessService { get; set; } = null!;

    public virtual ICollection<FitnessVisitAccaunt> FitnessVisitAccaunts { get; set; } = new List<FitnessVisitAccaunt>();
}
