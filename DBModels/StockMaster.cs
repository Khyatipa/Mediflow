using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class StockMaster
    {
        public int StockId { get; set; }
        public int? SitemId { get; set; }
        public int? StockQty { get; set; }
        public string BatchNo { get; set; }
        public DateTime? AddedDt { get; set; }
        public DateTime? ExpiryDt { get; set; }
        public bool? IsActive { get; set; }
    }
}
