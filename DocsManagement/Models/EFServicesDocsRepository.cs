using DocsManagement.Controllers;
using DocsManagement.LogHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DocsManagement.Models
{
    public class EFServicesDocsRepository : IServiceDocsRepository
    {
        private static readonly log4net.ILog log = LogHellper.GetLogger();

        private DocumentsDBEntities context = new DocumentsDBEntities();

        public IQueryable<Service> ServicesDocuments => context.Services;

        public void SaveServicesDocuments(ServiceDocument servicesDocS, String File)
        {
            try
            {
                FileInfo fil = new FileInfo(File);

                using (DocumentsDBEntities doc = new DocumentsDBEntities())
                {
                    var serdocs = new Service()
                    {
                        RegistrationNomer = servicesDocS.RegistrationNomer,
                        RegistrationData = servicesDocS.RegistrationData,
                        TypeDocument = servicesDocS.TypeDocument,
                        StateDocument = servicesDocS.StateDocument,
                        CreatedUser = servicesDocS.CreatedUser,
                        SignedUser = servicesDocS.SignedUser,
                        NumberSheets = servicesDocS.NumberSheets,
                        Summary = servicesDocS.Summary,
                        FileName = Path.GetFileName(File),
                        FileType = fil.Extension,
                        FileContent = System.IO.File.ReadAllBytes(File)

                    };
                    doc.Services.Add(serdocs);
                    doc.SaveChanges();

                }
            }
            catch (DbUpdateException ex)
            {
                log.Error("Can not use existing Registration nomer!", ex);
            }
        }

        public void DeleteServicesDocuments(int id)
        {
            Service doc = context.Services.Find(id);
            if (doc != null)
            {
                context.Services.Remove(doc);
                context.SaveChanges();
            }
        }
    }
}
