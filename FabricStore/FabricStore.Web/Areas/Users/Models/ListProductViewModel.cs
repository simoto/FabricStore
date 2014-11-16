using FabricStore.Models;
using FabricStore.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabricStore.Web.Areas.Users.Models
{
    public class ListProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Product, ListProductViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(y => y.Category.Name));
        }
    }
}