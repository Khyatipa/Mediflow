using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class OrderMaster
    {
        public int FinalOrderId { get; set; }
        public int? ChemistId { get; set; }
        public double? ValuePrice { get; set; }
        public double? Discount { get; set; }
        public double? GstCharges { get; set; }
        public double? FinalPayable { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryType { get; set; }
        public string IsActive { get; set; }
        public string OrderStatus { get; set; }
        public bool? IsCredit { get; set; }
        public DateTime? DeliveryStatusUpdate { get; set; }
    }
}
