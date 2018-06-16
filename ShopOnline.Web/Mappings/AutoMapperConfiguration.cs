﻿using AutoMapper;
using ShopOnline.Model.Models;
using ShopOnline.Web.Models;

namespace ShopOnline.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
              {
                  cfg.CreateMap<Post, PostViewModel>();
                  cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                  cfg.CreateMap<PostTag, PostTagViewModel>();
                  cfg.CreateMap<Tag, TagViewModel>();
                  cfg.CreateMap<Product, ProductViewModel>();
                  cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                  cfg.CreateMap<ProductTag, ProductTagViewModel>();
                  cfg.CreateMap<Order, OrderViewModel>();
                  cfg.CreateMap<OrderDetail, OrderDetailViewModel>();
                  cfg.CreateMap<Footer, FooterViewModel>();
                  cfg.CreateMap<Page, PageViewModel>();
                  cfg.CreateMap<Slide, SlideViewModel>();
                  cfg.CreateMap<SupportOnline, SupportOnlineViewModel>();
                  cfg.CreateMap<Function, FunctionViewModel>();
                  cfg.CreateMap<Permission, PermissionViewModel>();
                  cfg.CreateMap<AppRole, ApplicationRoleViewModel>();
                  cfg.CreateMap<AppUser,ApplicationUserViewModel>();                 
                  cfg.CreateMap<ProductImage, ProductImageViewModel>();
              });

         
    }
}
}