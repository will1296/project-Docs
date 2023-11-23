using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DocsManagement.Models
{
    public class Documents
    {
        [Key]
        public int RegistrationNomer { get; set; }
        [Required]
        [Display(Name = "Дата Регистрация Документа")]
        public System.DateTime RegistrationData { get; set; }
        [Required]
        [Display(Name = "Вид Документа")]
        public String TypeDocument { get; set; }
        [Required]
        [Display(Name = "Состояния Документа")]
        public String StateDocument { get; set; }
        [Required]
        [Display(Name = "создал")]
        public String CreatedUser { get; set; }
        [Required]
        [Display(Name = "подписал")]
        public String SignedUser { get; set; }
        public Nullable<int> NumberSheets { get; set; }
        public String Summary { get; set; }
        [Display(Name = "File")]
        public HttpPostedFileBase File { get; set; }
        //public HttpPostedFileBase File { get; set; }

    }
}
