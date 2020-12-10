using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOpration.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Class is required")]

        public string Class { get; set; }

       
    }
}
