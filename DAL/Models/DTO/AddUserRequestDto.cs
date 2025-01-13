using System.ComponentModel.DataAnnotations;

namespace DAL.Models.DTO
{
    public class AddUserRequestDto
    {
        [Required(ErrorMessage = "Indtast dit fornavn.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Indtast dit efternavn.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Indtast en e-mailadresse.")]
        [EmailAddress(ErrorMessage = "Indtast en gyldig e-mailadresse.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Indtast en adgangskode.")]
        [MinLength(6, ErrorMessage = "Adgangskoden skal være mindst 6 tegn.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Vælg et postnummer.")]
        public int PostalCodeId { get; set; }
    }
}
