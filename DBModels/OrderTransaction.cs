using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class OrderTransaction
    {
        public int OrderDetailId { get; set; }
        public int FinalOrderId { get; set; }
        public int? ChemistId { get; set; }
        public int? OitemId { get; set; }
        public int? ItemQty { get; set; }
        public string ObatchNo { get; set; }
        public DateTime? OexpiryDt { get; set; }
        public bool? OitemReturnStatus { get; set; }
    }
}
