using FabricStore.Data;
using FabricStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FabricStore.Models;

namespace FabricStore.Web.Controllers
{
    public class CommentsController : BaseController
    {
        public CommentsController(IUowData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {

                Comment dbComment = new Comment();
                dbComment.Content = comment.Content;
                dbComment.ProductId = comment.ProductId;
                dbComment.Author = this.UserProfile;
                dbComment.DateCreated = DateTime.Now;
                var product = this.data.Products.GetById(comment.ProductId);
                if (product == null)
                {
                    throw new HttpException(404, "Product not found!");
                }

                product.Comments.Add(dbComment);
                this.data.SaveChanges();

                var viewComment = Mapper.Map<CommentViewModel>(dbComment);

                return RedirectToAction("Details", new { Controller = "Products", area = string.Empty, id = comment.ProductId});
            }

            throw new HttpException(400, "Invalid comment");
        }
    }
}