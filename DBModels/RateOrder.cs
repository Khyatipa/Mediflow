using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class RateOrder
    {
        public int RatingId { get; set; }
        public int? RForderId { get; set; }
        public int? RCid { get; set; }
        public string RType { get; set; }
        public string RMsg { get; set; }
    }
}
