using AutoMapper;
using ShopOnline.Model.Models;
using ShopOnline.Service;
using ShopOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Web.Controllers
{
    public class AboutController : Controller
    {
        IAboutService _aboutService;
        public AboutController(IAboutService aboutServie)
        {
            this._aboutService = aboutServie;
        }
        // GET: About
        public ActionResult Index()
        {
            About aboutDb = _aboutService.GetSingle();
            AboutViewModel aboutVm = Mapper.Map<AboutViewModel>(aboutDb);
            return View(aboutVm);
        }

    }
}