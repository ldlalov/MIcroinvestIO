using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Document
{
    public int Id { get; set; }

    public int? Acct { get; set; }

    public string? InvoiceNumber { get; set; }

    public short? OperType { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public short? DocumentType { get; set; }

    public DateTime? ExternalInvoiceDate { get; set; }

    public string? ExternalInvoiceNumber { get; set; }

    public short? PaymentType { get; set; }

    public string? Recipient { get; set; }

    public string? Egn { get; set; }

    public string? Provider { get; set; }

    public DateTime? TaxDate { get; set; }

    public string? Reason { get; set; }

    public string? Description { get; set; }

    public string? Place { get; set; }
}
