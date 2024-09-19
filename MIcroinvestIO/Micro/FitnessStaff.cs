using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessStaff
{
    public int FitnessStaffId { get; set; }

    public int UserId { get; set; }

    public int FitnessStaffType { get; set; }

    public int CardId { get; set; }

    public virtual FitnessCard Card { get; set; } = null!;
}
