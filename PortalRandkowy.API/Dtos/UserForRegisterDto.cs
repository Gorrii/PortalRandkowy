using System.ComponentModel.DataAnnotations;

namespace PortalRandkowy.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage="Nazwa Uzytkownika jest wymagana")]
        public string UserName { get; set; }  
        
        [Required(ErrorMessage="haslo  jest wymagana")]
        [StringLength(12,MinimumLength=6, ErrorMessage="min 6 max 12")]
        public string Password { get; set; }  
    }
}