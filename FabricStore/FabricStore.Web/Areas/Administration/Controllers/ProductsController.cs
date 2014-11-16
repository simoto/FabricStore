namespace FabricStore.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using FabricStore.Data;
    using FabricStore.Models;
    using FabricStore.Web.Areas.Administration.Models;

    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/Products
        public ActionResult Index()
        {
            var products = this.db.Products.Include(p => p.Category).Include(p => p.Manufacturer);
            return this.View(products.ToList());
        }

        // GET: Administration/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        // GET: Administration/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(this.db.Manufacturers, "Id", "Name");
            return this.View();
        }

        // POST: Administration/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,CategoryId,Image,Description,ManufacturerId,IsAvailable,AvailableAmount,DataAdded")] ProductAdminCreateViewModel product)
        {           
            if (ModelState.IsValid)
            {
                if (product.Image == null)
                {
                    ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", product.CategoryId);
                    ViewBag.ManufacturerId = new SelectList(this.db.Manufacturers, "Id", "Name", product.ManufacturerId);
                    return this.View(product);
                }

                Product newProduct = new Product()
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
                    Image = this.HttpPostedFileToByteArray(product.Image)
                };

                this.db.Products.Add(newProduct);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(this.db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return this.View(product);
        }

        // GET: Administration/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this.db.Products.Find(id);
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
                return this.HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(this.db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return this.View(current);
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
                    var currentProduct = this.db.Products.Find(product.Id);
                    currentProduct.Id = product.Id;
                    currentProduct.CategoryId = product.CategoryId;
                    currentProduct.Name = product.Name;
                    currentProduct.Price = product.Price;
                    currentProduct.AvailableAmount = product.AvailableAmount;
                    currentProduct.DataAdded = product.DataAdded;
                    currentProduct.Description = product.Description;
                    currentProduct.IsAvailable = product.IsAvailable;
                    currentProduct.ManufacturerId = product.ManufacturerId;
                    this.db.Entry(currentProduct).State = EntityState.Modified;
                    this.db.SaveChanges();
                    return this.RedirectToAction("Index");
                }

                editedProduct.Image = this.HttpPostedFileToByteArray(product.Image);
                this.db.Entry(editedProduct).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(this.db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return this.View(product);
        }

        // GET: Administration/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = this.db.Products.Find(id);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        public ActionResult GetImage(int id)
        {
            byte[] image = this.db.Products.FirstOrDefault(x => x.Id == id).Image;
            return this.File(image, "image/jpg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private byte[] HttpPostedFileToByteArray(HttpPostedFileBase file)
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
