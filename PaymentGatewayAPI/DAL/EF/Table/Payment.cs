using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class Payment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public decimal Amount { get; set; }

    public string? TransactionId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
