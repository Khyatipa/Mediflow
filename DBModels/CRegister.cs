using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class CRegister
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Rdlno { get; set; }
        public string GstNo { get; set; }
        public string Email { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zcode { get; set; }
        public string Status { get; set; }
        public bool? IsCredit { get; set; }
        public byte[] DocumentImg { get; set; }
    }
}
