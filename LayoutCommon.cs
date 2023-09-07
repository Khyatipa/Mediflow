using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mediflow.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Mediflow
{
    public class LayoutCommon
    {
        public  Mediflow.DBModels.MediflowContext _context;


        MediflowContext s = new MediflowContext();


        public List<NotifyChemist> NotifyChemist { get; set; }
        
       public void LoadDetials(int cid)
        {
            //string a = this.HttpContext.Session.GetString("username");
            //if (a == null)
            //{
            //    TempData["TempUser"] = a;
            //    return RedirectToPage("/Home/Index");
            //}
            NotifyChemist = s.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            
            // HttpContext.Session.SetInt32("cartQty", countQty);
            //ViewData["countItem"] = countQQty;
            //return NotifyChemist;
        }
        public int LoadCount(int cid)
        {
            int countQQty = s.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            return countQQty;
        }
    }

}     
