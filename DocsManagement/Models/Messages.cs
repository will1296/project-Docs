using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DocsManagement.Models
{
    public class Messages
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Message1 { get; set; }
        [Display(Name = "File")]
        public HttpPostedFileBase File { get; set; }
    }
}