using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessAddIn
{
    public int FitnessAddInId { get; set; }

    public int VisitCardsId { get; set; }

    public string Name { get; set; } = null!;

    public bool State { get; set; }

    public DateTime UpdateDate { get; set; }

    public int ActiveUserId { get; set; }

    public virtual FitnessVisitCard VisitCards { get; set; } = null!;
}
