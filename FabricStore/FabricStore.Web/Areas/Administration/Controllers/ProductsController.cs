using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FabricStore.Data;
using FabricStore.Models;
using FabricStore.Web.Areas.Administration.Models;
using AutoMapper.QueryableExtensions;
using System.IO;
using System.Drawing;

namespace FabricStore.Web.Areas.Administration.Controllers
{
    //[Authorize(Roles="Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Manufacturer);
            return View(products.ToList());
        }

        // GET: Administration/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }


            return View(product);
        }

        // GET: Administration/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: Administration/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,CategoryId,Image,Description,ManufacturerId,IsAvailable,AvailableAmount,DataAdded")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // GET: Administration/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            ProductAdminViewModel current = new ProductAdminViewModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                AvailableAmount = product.AvailableAmount,
                DataAdded = product.DataAdded,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                ManufacturerId = product.ManufacturerId,
                Image = null
            };

            if (product == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(current);
        }

        // POST: Administration/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,CategoryId,Image,Description,ManufacturerId,IsAvailable,AvailableAmount,DataAdded")] ProductAdminViewModel product)
        {
            
            if (ModelState.IsValid)
            {
                Product editedProduct = new Product()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    Price = product.Price,
                    AvailableAmount = product.AvailableAmount,
                    DataAdded = product.DataAdded,
                    Description = product.Description,
                    IsAvailable = product.IsAvailable,
                    ManufacturerId = product.ManufacturerId                    
                };

                if (product.Image == null)
                {
                    var currentProduct = db.Products.Find(product.Id);
                    currentProduct.Id = product.Id;
                    currentProduct.CategoryId = product.CategoryId;
                    currentProduct.Name = product.Name;
                    currentProduct.Price = product.Price;
                    currentProduct.AvailableAmount = product.AvailableAmount;
                    currentProduct.DataAdded = product.DataAdded;
                    currentProduct.Description = product.Description;
                    currentProduct.IsAvailable = product.IsAvailable;
                    currentProduct.ManufacturerId = product.ManufacturerId;
                    db.Entry(currentProduct).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                editedProduct.Image = this.httpPostedFileToByteArray(product.Image);
                db.Entry(editedProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // GET: Administration/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetImage(int id)
        {
            byte[] image = this.db.Products.FirstOrDefault(x => x.Id == id).Image;
            return File(image, "image/jpg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private byte[] httpPostedFileToByteArray(HttpPostedFileBase file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }

            return data;
        }
    }
}
