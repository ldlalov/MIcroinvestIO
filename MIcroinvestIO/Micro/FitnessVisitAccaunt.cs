using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessVisitAccaunt
{
    public int FitnessVisitAccauntId { get; set; }

    public int FitnessVisitId { get; set; }

    public int Acct { get; set; }

    public int OperId { get; set; }

    public virtual FitnessVisit FitnessVisit { get; set; } = null!;
}
