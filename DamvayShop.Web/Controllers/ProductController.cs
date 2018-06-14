using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DamvayShop.Model.Models;
using DamvayShop.Service;
using DamvayShop.Web.Infrastructure.Core;
using DamvayShop.Web.Models;

namespace DamvayShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private ITagService _tagService;
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        private IProductImageService _productImageService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IProductImageService productImageService,
          ITagService tagService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._productImageService = productImageService;
            this._tagService = tagService;
            
        }
        // GET: ProductCategory
      
        public ActionResult Index(int id, int page = 1, string sort = "")
        {
            ProductCategory category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategoryViewModel>(category);
            ViewBag.Sort = sort;
            int pageSize = Common.CommonConstant.PageSize;
            int totalRow = 0;
            IEnumerable<Product> listProductDb = _productService.GetAllByCategoryPaging(id, page, pageSize, sort, out totalRow);
            IEnumerable<ProductViewModel> listProductVm = Mapper.Map<IEnumerable<ProductViewModel>>(listProductDb);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            PaginationClient<ProductViewModel> pagination = new PaginationClient<ProductViewModel>()
            {
                TotalPage = totalPage,
                TotalRows = totalRow,
                PageDisplay = Common.CommonConstant.PageDisplay,
                Items= listProductVm,
                PageIndex=page,
                PageSize=pageSize,

            };
            IEnumerable<Tag> listTagProdut = _tagService.GetAll().Where(x => x.Type == Common.CommonConstant.ProductTag.ToString()).OrderByDescending(x => x.ID).Take(9);
            IEnumerable<TagViewModel> listTagVm = Mapper.Map<IEnumerable<TagViewModel>>(listTagProdut);
            ViewBag.TagProduct=listTagVm;
            return View(pagination);
        } 
        public JsonResult GetListProductByName(string prodcuctName)
        {
           IEnumerable<string> listProductName = _productService.GetProductName(prodcuctName);
            return Json(new
            {
                data = listProductName
            },JsonRequestBehavior.AllowGet);
                
            
        }

        public ActionResult Detail(int id)
        {
            Product productDb = _productService.GetById(id);
            ProductViewModel productVm = Mapper.Map<ProductViewModel>(productDb);
            
            IEnumerable<Product> listProductDb = _productService.GetProductRelate(productVm.CategoryID);
            IEnumerable<ProductViewModel> listProductVm = Mapper.Map<IEnumerable<ProductViewModel>>(listProductDb);
            IEnumerable<ProductImage> listProductImageDb = _productImageService.GetProductImageByProdutID(id);
            IEnumerable<ProductImageViewModel> listProductImageVm = Mapper.Map<IEnumerable<ProductImageViewModel>>(listProductImageDb);
            IEnumerable<Tag> listTagDb = _tagService.GetTagByProductId(id);
            IEnumerable<TagViewModel> listTagVm = Mapper.Map<IEnumerable<TagViewModel>>(listTagDb);
            ViewBag.TagProducts = listTagVm;
            ViewBag.ProductCategory = productDb.ProductCategory;

            ProductDetailViewModel ProductDetail = new ProductDetailViewModel()
            {
                ListProductImageVm = listProductImageVm,
                ListProductVm = listProductVm,
                ProductVm = productVm,
            
            };
            return View(ProductDetail);

        }
 
        public ActionResult Tag(string tagId, int page=1)
        {
            int pageSize = Common.CommonConstant.PageSize;
            int totalRow = 0;
            IEnumerable<Product> listProductDb = _productService.GetAllByTagPaging(tagId, page, pageSize, out totalRow);
            IEnumerable<ProductViewModel> listProductVm = Mapper.Map<IEnumerable<ProductViewModel>>(listProductDb);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            PaginationClient<ProductViewModel> pagination = new PaginationClient<ProductViewModel>()
            {
                PageIndex=page,
                PageDisplay=Common.CommonConstant.PageDisplay,
                PageSize=pageSize,
                TotalPage=totalPage,
                TotalRows=totalRow,
                Items=listProductVm,
            };
            ViewBag.ProductTag =Mapper.Map<TagViewModel>(_tagService.GetDetail(tagId));
            return View(pagination);

        }
    }
}