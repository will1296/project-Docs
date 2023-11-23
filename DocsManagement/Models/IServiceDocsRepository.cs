using System;
using System.Linq;


namespace DocsManagement.Models
{
    public interface IServiceDocsRepository
    {
        IQueryable<Service> ServicesDocuments { get; }

	    void SaveServicesDocuments(ServiceDocument servicesDocuments, String File);

        void DeleteServicesDocuments(int serviceDocsID);
    }
}
