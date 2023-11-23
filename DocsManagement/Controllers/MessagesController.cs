using DocsManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocsManagement.Controllers
{
    public class MessagesController : Controller
    {
        DocumentsDBEntities context = new DocumentsDBEntities();

        // GET: Messages
        public ActionResult List()
        {
            return View(context.Messages);
        }

        // GET: Messages/Details/5 
        public ActionResult Details(int id)
        {
            Message post = context.Messages.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        public ActionResult Create(Messages post)
        {
            if (ModelState.IsValid)
            {
                String File = SaveToPhysicalLocation(post.File);
                FileInfo fil = new FileInfo(File);

                using (DocumentsDBEntities entity = new DocumentsDBEntities())
                {
                    var message = new Message()
                    {
                        Sender = post.Sender,
                        Reciever = post.Reciever,
                        Message1 = post.Message1,
                        FileName = Path.GetFileName(File),
                        FileType = fil.Extension,
                        FileContent = System.IO.File.ReadAllBytes(File)

                    };
                    entity.Messages.Add(message);
                    entity.SaveChanges();

                }
                return RedirectToAction("List");
            }
            return View(post);
        }

        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/PostFiles"), fileName);
                file.SaveAs(path);
                return path;
            }
            return string.Empty;
        }

        [HttpGet]
        public FileResult Download(int id)
        {
            Message doc = context.Messages.Find(id);
            return File(doc.FileContent, doc.FileType, doc.FileName);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int id)
        {
             Message post = context.Messages.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message post = context.Messages.Find(id);
            if (post != null)
            {
                context.Messages.Remove(post);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
