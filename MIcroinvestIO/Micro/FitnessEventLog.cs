using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessEventLog
{
    public int FitnessEventId { get; set; }

    public int? FitnessCardId { get; set; }

    public int Reader { get; set; }

    public DateTime DateTime { get; set; }

    public int StatusType { get; set; }

    public int? FitnessVisitCardId { get; set; }

    public string? Comment { get; set; }

    public int? ObjectId { get; set; }

    public virtual FitnessCard? FitnessCard { get; set; }
}
