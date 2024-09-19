using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessDailyReport
{
    public int FitnessDailyReportId { get; set; }

    public int Number { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Total { get; set; }

    public int UserId { get; set; }

    public DateTime? UserRealTime { get; set; }
}
