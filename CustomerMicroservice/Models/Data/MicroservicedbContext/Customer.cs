using System;
using System.Collections.Generic;

namespace CustomerMicroservice.Models.Data.MicroservicedbContext;

public partial class Customer
{
    public int Customerid { get; set; }

    public string Customername { get; set; } = null!;

    public string Customercontact { get; set; } = null!;

    public string Customerlocation { get; set; } = null!;
}
