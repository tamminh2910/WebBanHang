using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Model.Entities;
using WebBanHang.Web.Models;

namespace WebBanHang.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryChild, CategoryChildViewModel>();
                cfg.CreateMap<CategoryParent, CategoryParentViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
            });
        }
    }
}