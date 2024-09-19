using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessCard
{
    public int FitnessCardId { get; set; }

    public bool IsBusy { get; set; }

    public bool IsActive { get; set; }

    public string InternalNumber { get; set; } = null!;

    public string HumanName { get; set; } = null!;

    public int CardType { get; set; }

    public DateTime? EnterTime { get; set; }

    public int CurrentPosition { get; set; }

    public int? UserId { get; set; }

    public bool Deleted { get; set; }

    public int? FitnessPlanId { get; set; }

    public virtual ICollection<FitnessEventLog> FitnessEventLogs { get; set; } = new List<FitnessEventLog>();

    public virtual ICollection<FitnessStaff> FitnessStaffs { get; set; } = new List<FitnessStaff>();

    public virtual ICollection<FitnessVisitCard> FitnessVisitCards { get; set; } = new List<FitnessVisitCard>();
}
