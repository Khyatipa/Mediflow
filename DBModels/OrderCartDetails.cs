using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class OrderCartDetails
    {
        public int OrderId { get; set; }
        public int? ChemistId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemQty { get; set; }
    }
}
