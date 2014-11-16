namespace FabricStore.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using FabricStore.Data;
    using FabricStore.Models;

    [Authorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/Comments
        public ActionResult Index()
        {
            var comments = this.db.Comments.Include(c => c.Author).Include(c => c.Product);
            return this.View(comments.ToList());
        }

        // GET: Administration/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.db.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(comment);
        }

        // GET: Administration/Comments/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(this.db.Users, "Id", "Email");
            ViewBag.ProductId = new SelectList(this.db.Products, "Id", "Name");
            return this.View();
        }

        // POST: Administration/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,AuthorId,Content,DateCreated")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.db.Comments.Add(comment);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(this.db.Users, "Id", "Email", comment.AuthorId);
            ViewBag.ProductId = new SelectList(this.db.Products, "Id", "Name", comment.ProductId);
            return this.View(comment);
        }

        // GET: Administration/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.db.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.AuthorId = new SelectList(this.db.Users, "Id", "Email", comment.AuthorId);
            ViewBag.ProductId = new SelectList(this.db.Products, "Id", "Name", comment.ProductId);
            return this.View(comment);
        }

        // POST: Administration/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,AuthorId,Content,DateCreated")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(comment).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(this.db.Users, "Id", "Email", comment.AuthorId);
            ViewBag.ProductId = new SelectList(this.db.Products, "Id", "Name", comment.ProductId);
            return this.View(comment);
        }

        // GET: Administration/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.db.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(comment);
        }

        // POST: Administration/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.db.Comments.Find(id);
            this.db.Comments.Remove(comment);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
