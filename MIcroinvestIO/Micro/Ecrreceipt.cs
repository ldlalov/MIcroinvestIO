using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Ecrreceipt
{
    public int Id { get; set; }

    public int OperType { get; set; }

    public int Acct { get; set; }

    public int ReceiptId { get; set; }

    public DateTime? ReceiptDate { get; set; }

    public int ReceiptType { get; set; }

    public string? Ecrid { get; set; }

    public string? Description { get; set; }

    public double? Total { get; set; }

    public int UserId { get; set; }

    public DateTime? UserRealTime { get; set; }
}
