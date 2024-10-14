﻿using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class Partner
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Company { get; set; }

    public string? Company2 { get; set; }

    public string? Mol { get; set; }

    public string? Mol2 { get; set; }

    public string? City { get; set; }

    public string? City2 { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string? Phone { get; set; }

    public string? Phone2 { get; set; }

    public string? Fax { get; set; }

    public string? EMail { get; set; }

    public string? TaxNo { get; set; }

    public string? Bulstat { get; set; }

    public string? BankName { get; set; }

    public string? BankCode { get; set; }

    public string? BankAcct { get; set; }

    public string? BankVatname { get; set; }

    public string? BankVatcode { get; set; }

    public string? BankVatacct { get; set; }

    public int? PriceGroup { get; set; }

    public double? Discount { get; set; }

    public short? Type { get; set; }

    public short? IsVeryUsed { get; set; }

    public int? UserId { get; set; }

    public int? GroupId { get; set; }

    public DateTime? UserRealTime { get; set; }

    public int? Deleted { get; set; }

    public string? CardNumber { get; set; }

    public string? Note1 { get; set; }

    public string? Note2 { get; set; }

    public int? PaymentDays { get; set; }
}
