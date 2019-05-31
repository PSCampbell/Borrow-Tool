using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BorrowTools.Models;

namespace BorrowTools.Controllers
{
    public class HireController : Controller
    {
        private BorrowToolEntities1 db = new BorrowToolEntities1();

        // GET: Hire
        public ActionResult Index()
        {
            return View();
        }

        public void ExportToCSV()
        {
            var sb = new StringBuilder();
            var data = from t in db.Tools
                       select new
                       {
                           t.toolID,
                           t.toolName,
                           t.toolBrand,
                           t.toolNotes,
                           t.toolAvailable //needs to be t.toolAvailable where t.toolAvailable == true / false
                       };

            var list = data.ToList();
            var grid = new System.Web.UI.WebControls.GridView();

            grid.DataSource = list;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Items.xls");
            Response.ContentType = "application/vnd.ms-excel";

            StringWriter sw = new StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            
        }

        public ActionResult Available()
        {
            return View(db.Tools.ToList());
        }
        public ActionResult Unavailable()
        {
            return View(db.Tools.ToList());
        }

        public ActionResult Hire(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hire([Bind(Include = "toolID,toolName,toolBrand,toolNotes,toolAvailable")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tool);
        }

        // GET: Hire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // GET: Hire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "toolID,toolName,toolBrand,toolNotes,toolAvailable")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Tools.Add(tool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tool);
        }

        // GET: Hire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Hire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "toolID,toolName,toolBrand,toolNotes,toolAvailable")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tool);
        }

        // GET: Hire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Hire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tool tool = db.Tools.Find(id);
            db.Tools.Remove(tool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
