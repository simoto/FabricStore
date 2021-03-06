﻿namespace FabricStore.Web.Controllers
{
    using FabricStore.Data;
    using FabricStore.Models;
    using FabricStore.Web.Models;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System;
    using System.Web;
    using System.Web.Mvc;

    public class CommentsController : BaseController
    {
        public CommentsController(IUowData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                Comment databaseComment = new Comment();
                databaseComment.Content = comment.Content;
                databaseComment.ProductId = comment.ProductId;
                databaseComment.Author = this.UserProfile;
                databaseComment.DateCreated = DateTime.Now;
                var product = this.data.Products.GetById(comment.ProductId);
                if (product == null)
                {
                    throw new HttpException(404, "Product not found!");
                }

                product.Comments.Add(databaseComment);
                this.data.SaveChanges();

                return PartialView("_ProductCommentsPartial", product.Comments.AsQueryable().Project().To<CommentViewModel>());
               //return this.RedirectToAction("GetComments", new { Controller = "Products", area = string.Empty, id = comment.ProductId });
            }

            throw new HttpException(400, "Invalid data!");
        }
    }
}