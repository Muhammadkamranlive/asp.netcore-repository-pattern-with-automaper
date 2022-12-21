using System.ComponentModel.DataAnnotations;

namespace Trevoir.DTOS
{
    public class UserLoginDTO 
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First Name is of 100 charachter max")]
        public string Password { get; set; }

    }
    public class UserDTOS:UserLoginDTO
    {
        [Required]
        [StringLength(100,ErrorMessage ="First Name is of 100 charachter max")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "First Name is of 100 charachter max")]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }
    }

    
}
