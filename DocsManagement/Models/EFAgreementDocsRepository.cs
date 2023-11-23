using DocsManagement.LogHelper;
using System;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace DocsManagement.Models
{
    
    public class EFAgreementDocsRepository : IAgreementDocsRepository
    {
        private static readonly log4net.ILog log = LogHellper.GetLogger();

        private DocumentsDBEntities context = new DocumentsDBEntities();

        public IQueryable<Agreement> AgreementDocuments => context.Agreements;

        public void SaveAgreementDocuments(AgreementDocument agreementDocs, String File)
        {
            try
            {
                FileInfo fil = new FileInfo(File);

                using (DocumentsDBEntities doc = new DocumentsDBEntities())
                {
                    var agDoc = new Agreement()
                    {
                        RegistrationNomer = agreementDocs.RegistrationNomer,
                        RegistrationData = agreementDocs.RegistrationData,
                        TypeDocument = agreementDocs.TypeDocument,
                        StateDocument = agreementDocs.StateDocument,
                        TypeAgreement = agreementDocs.TypeAgreement,
                        DeadlineAgreement = agreementDocs.DeadlineAgreement,
                        Conractor = agreementDocs.Contractor,
                        Amount = agreementDocs.Amount,
                        CreatedUser = agreementDocs.CreatedUser,
                        SignedUser = agreementDocs.SignedUser,
                        NumberSheets = agreementDocs.NumberSheets,
                        Summary = agreementDocs.Summary,
                        FileName = Path.GetFileName(File),
                        FileType = fil.Extension,
                        FileContent = System.IO.File.ReadAllBytes(File)

                    };
                    doc.Agreements.Add(agDoc);
                    doc.SaveChanges();

                }
            }
            catch (DbUpdateException ex)
            {
                log.Error("Can not use existing Registration nomer!", ex);
            }
        }

        public void DeleteAgreementDocuments(int agreementDocsID)
        {
            Agreement doc = context.Agreements.Find(agreementDocsID);
            if(doc != null)
            {
                context.Agreements.Remove(doc);
                context.SaveChanges();
            }
        }
    }
}
