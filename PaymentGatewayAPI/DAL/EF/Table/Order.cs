using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
