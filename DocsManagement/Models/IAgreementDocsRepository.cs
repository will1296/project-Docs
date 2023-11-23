using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsManagement.Models
{
    public interface IAgreementDocsRepository
    {
        IQueryable<Agreement> AgreementDocuments { get; }

	    void SaveAgreementDocuments(AgreementDocument agreementDocuments, String File);

        void DeleteAgreementDocuments(int agreementDocsID);
    }
}
