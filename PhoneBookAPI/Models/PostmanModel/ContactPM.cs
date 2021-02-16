using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models.PostmanModel
{
    public class ContactPM
    {
        [Required]
        public int UserID { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Telefon numarasını başında 0 olmadan 10 hane olarak giriniz.")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
