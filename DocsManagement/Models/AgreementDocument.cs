using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocsManagement.Models
{
    public class AgreementDocument : Documents
    {
        [Required]
        [Display(Name = "Вид Договора")]
        public string TypeAgreement { get; set; }
        [Required]
        [Display(Name = "срок Договора")]
        public System.DateTime DeadlineAgreement { get; set; }
        [Required]
        [Display(Name = "контрагента")]
        public string Contractor { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
          ErrorMessage = "Введите, Положительную Цену")]
        public decimal Amount { get; set; }
    }
}