using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Controllers
{
    public class ContactController : Controller
    {
        private ISupportOnlineService _supportService;
        public ContactController(ISupportOnlineService supportService)
        {
            this._supportService = supportService;
        }
        // GET: Contact
        public ActionResult Index()
        {
            SupportOnline supportOnlineDb = _supportService.Get();
            SupportOnlineViewModel supportOnlineVm = Mapper.Map<SupportOnlineViewModel>(supportOnlineDb);
            return View(supportOnlineVm);
        }
    }
}