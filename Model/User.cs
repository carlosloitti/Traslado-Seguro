using System.ComponentModel.DataAnnotations;

namespace Traslado_Seguro.Model
{
    public class User
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

    }
}
