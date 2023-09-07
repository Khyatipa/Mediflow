using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class BookMarkProductsChemist
    {
        public int BookmarkId { get; set; }
        public int? BookedItemId { get; set; }
        public int? ChemistId { get; set; }
        public bool? Flag { get; set; }
    }
}
