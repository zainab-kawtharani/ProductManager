using System.ComponentModel.DataAnnotations;

namespace EmployeeBackend.ViewModel
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="password and confirm password are not match")]
        public string ConfirmPassword { get; set; }
    }
}
