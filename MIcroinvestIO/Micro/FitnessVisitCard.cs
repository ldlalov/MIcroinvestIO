using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessVisitCard
{
    public int FitnessVisitCardsId { get; set; }

    public int FitnessVisitId { get; set; }

    public int FitnessCardId { get; set; }

    public int VisitCardUsed { get; set; }

    public int VisitCardAllowed { get; set; }

    public int InstructorUsed { get; set; }

    public int InstructorAllowed { get; set; }

    public DateTime? StartDate { get; set; }

    public bool Deleted { get; set; }

    public DateTime? EndDate { get; set; }

    public string? OwnerName { get; set; }

    public int CurrentVisitCardReduction { get; set; }

    public bool IsPrimary { get; set; }

    public int DailyTrainUsed { get; set; }

    public virtual ICollection<FitnessAddIn> FitnessAddIns { get; set; } = new List<FitnessAddIn>();

    public virtual FitnessCard FitnessCard { get; set; } = null!;

    public virtual ICollection<FitnessInstructorIn> FitnessInstructorIns { get; set; } = new List<FitnessInstructorIn>();
}
