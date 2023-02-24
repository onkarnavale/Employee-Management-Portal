using System.ComponentModel.DataAnnotations;

namespace Mini_project.Models
{
    public class Employee
    {
        [Display(Name ="Employee-id ")]
        //[Required(ErrorMessage = "{0} *Required")]
        [Range(9000,9999,ErrorMessage ="id must be in range of 9000,9999")]
        public int eid { get; set; }

        [Display(Name = "Name ")]
        [Required(ErrorMessage = "*Required")]
        [StringLength(20,ErrorMessage ="must not exceed more than 15 character")]
        public string ename { get; set; }

        [Display(Name = "Email-id ")]
        [Required(ErrorMessage = "*Required")]
        [EmailAddress(ErrorMessage ="please enter email in valid format")]
        public string email { get; set; }

        [Display(Name = "Password ")]
        [Required(ErrorMessage = "*Required")]
        public string epass { get; set; }

        [Display(Name = "Phone number ")]
        //[Required(ErrorMessage = "*Required")]
        public int phone { get; set; }

        [Display(Name = "Designation")]
        public string designation { get; set; }
    }
}




