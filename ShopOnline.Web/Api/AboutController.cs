using AutoMapper;
using ShopOnline.Model.Models;
using ShopOnline.Service;
using ShopOnline.Web.Infrastructure.Core;
using ShopOnline.Web.Infrastructure.Extensions;
using ShopOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopOnline.Web.Api
{
    [RoutePrefix("api/about")]
    [Authorize]
    public class AboutController : ApiControllerBase
    {
       private IAboutService _aboutService;

        public AboutController(IErrorService errorService, IAboutService aboutService):base(errorService)
        {
            this._aboutService = aboutService;
        }

        [Route("get")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {                          
                 About aboutDb = _aboutService.GetSingle();
                AboutViewModel aboutVm = Mapper.Map<AboutViewModel>(aboutDb);
                return request.CreateResponse(HttpStatusCode.OK, aboutVm);
            };

            return CreateHttpResponse(request, func);
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, AboutViewModel aboutVm)
        {
            return CreateHttpResponse(request, () =>
            {           
                if (ModelState.IsValid)
                {
                    About aboutDb = new About();
                    aboutDb.UpdateAbout(aboutVm);
                    _aboutService.Create(aboutDb);
                    _aboutService.SaveChange();
                    return request.CreateResponse(HttpStatusCode.Created, aboutVm);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, AboutViewModel aboutVm)
        {
            return CreateHttpResponse(request, () =>
            {
                if (ModelState.IsValid)
                {
                    About aboutDb = _aboutService.GetSingle();
                    aboutDb.UpdateAbout(aboutVm);
                    _aboutService.Update(aboutDb);
                    _aboutService.SaveChange();
                    return request.CreateResponse(HttpStatusCode.Created, aboutVm);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                    _aboutService.Delete(id);
                    _aboutService.SaveChange();
                    return request.CreateResponse(HttpStatusCode.OK, id);
             
            });
        }
    }
}
