using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class Products
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string MfgByName { get; set; }
        public string MarketByName { get; set; }
        public string MedicineType { get; set; }
        public int? Mrp { get; set; }
        public double? Rate { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Volume { get; set; }
        public string Unit { get; set; }
        public byte[] Image { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public int? HsnCode { get; set; }
        public string ProductCategory { get; set; }
        public double? GstPercent { get; set; }
        public double? MarginPercent { get; set; }
    }
}
