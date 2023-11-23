using DocsManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocsManagement.Controllers
{
    public class ServiceDocsController : Controller
    {
        DocumentsDBEntities context = new DocumentsDBEntities();
        EFServicesDocsRepository ef = new EFServicesDocsRepository();
        // GET: AgreementDocs
        [Authorize(Roles = "Employee, Admin, Manager")]
        public ActionResult List()
        {
            return View(ef.ServicesDocuments);
        }

        // GET: AgreementDocs/Details/5
        [Authorize(Roles = "Employee, Admin, Manager")]
        public ActionResult Details(int id)
        {
            Service doc = context.Services.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            return View(doc);
        }

        // GET: AgreementDocs/Create
        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgreementDocs/Create
        [HttpPost]
        public ActionResult Create(ServiceDocument serviceDocs)
        {
            if (ModelState.IsValid)
            {
                String File = SaveToPhysicalLocation(serviceDocs.File);
                ef.SaveServicesDocuments(serviceDocs, File);
                return RedirectToAction("List");
            }

            return View(serviceDocs);
        }

        public string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/ServiceDocFiles"), fileName);
                file.SaveAs(path);
                return path;
            }
            return string.Empty;
        }

        [HttpGet]
        public FileResult Download(int id)
        {
            Service doc = context.Services.Find(id);
            return File(doc.FileContent, doc.FileType, doc.FileName);
        }


        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int id)
        {
            Service doc = context.Services.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            return View(doc);
        }

        [HttpPost]
        public ActionResult Edit(Service doc)
        {
            if (ModelState.IsValid)
            {
                context.Entry(doc).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(doc);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int id)
        {
            Service doc = context.Services.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            return View(doc);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ef.DeleteServicesDocuments(id);
            return RedirectToAction("List");
        }
    }
}
