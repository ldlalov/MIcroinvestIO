using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessInstructorIn
{
    public int FitnessInstructorInsId { get; set; }

    public int VisitCardsId { get; set; }

    public int InstructorId { get; set; }

    public DateTime UpdateDate { get; set; }

    public int ActiveUserId { get; set; }

    public virtual FitnessVisitCard VisitCards { get; set; } = null!;
}
