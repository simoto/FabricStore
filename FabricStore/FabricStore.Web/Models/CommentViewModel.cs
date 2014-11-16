using AutoMapper;
using FabricStore.Models;
using FabricStore.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabricStore.Web.Models
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(c => c.Author.UserName));
        }
    }
}