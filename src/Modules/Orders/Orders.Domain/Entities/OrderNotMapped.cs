﻿namespace Orders.Domain
{
    public partial class Order
    {
        [NotMapped] public CustomerDTO? Customer { get; set; }
        [NotMapped] public EmployeeDTO? Employee { get; set; }
    }
}