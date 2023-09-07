using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class ReturnMaster
    {
        public int RmasterId { get; set; }
        public int? RmFinalOrderId { get; set; }
        public DateTime? RmDate { get; set; }
        public double? RmValuePrice { get; set; }
        public double? RmGstCharge { get; set; }
        public double? RmFinalPayable { get; set; }
        public bool? RmIstypeExpiry { get; set; }
        public bool? RmIsNewRecord { get; set; }
        public int? RmCid { get; set; }
    }
}
