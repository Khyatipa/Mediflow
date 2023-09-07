using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class ReturnItem
    {
        public int ReturnId { get; set; }
        public int? RmId { get; set; }
        public int? RfinalOrderId { get; set; }
        public int? RitemId { get; set; }
        public int? RchemistId { get; set; }
        public string RbatchNo { get; set; }
        public int? RitemQty { get; set; }
        public DateTime? RitemExpiry { get; set; }
        public string RpaymentType { get; set; }
        public DateTime? RinitiateDate { get; set; }
        public bool? RIstypeExpiry { get; set; }
    }
}
