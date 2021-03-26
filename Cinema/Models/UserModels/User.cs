using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models.UserModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add Name")]
        [MinLength(3,ErrorMessage ="Min 3 character")]
        [MaxLength(10,ErrorMessage ="Max 10 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please add Surname")]
        [MinLength(5, ErrorMessage = "Min 5 character")]
        [MaxLength(15, ErrorMessage = "Max 15 character")]
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Please add Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please add PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please add Password")]
        [MinLength(3, ErrorMessage = "Min 3 character")]
        [MaxLength(1000, ErrorMessage = "Max 1000 character")]
        public string Password { get; set; }

    }
}