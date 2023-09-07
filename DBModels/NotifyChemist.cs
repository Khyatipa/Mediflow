using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class NotifyChemist
    {
        public int NotifyCid { get; set; }
        public int? ChemistId { get; set; }
        public string NotifyMsg { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string NotifyType { get; set; }
        public bool? NotifyIsRead { get; set; }
    }
}
