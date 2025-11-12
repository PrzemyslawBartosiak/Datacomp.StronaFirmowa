using System.ComponentModel.DataAnnotations;

namespace Datacomp.StronaFirmowa.Fundament.Models.DTOs
{
    public class FormularzKontaktowyDto
    {
        [Required(ErrorMessage = "Imiê jest wymagane")]
        [StringLength(100, ErrorMessage = "Imiê nie mo¿e byæ d³u¿sze ni¿ 100 znaków")]
        public string Imie { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawid³owy format email")]
        [StringLength(100, ErrorMessage = "Email nie mo¿e byæ d³u¿szy ni¿ 100 znaków")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Nieprawid³owy format telefonu")]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Temat jest wymagany")]
        [StringLength(200, ErrorMessage = "Temat nie mo¿e byæ d³u¿szy ni¿ 200 znaków")]
        public string Temat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Wiadomoœæ jest wymagana")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Wiadomoœæ musi mieæ od 10 do 2000 znaków")]
        public string Wiadomosc { get; set; } = string.Empty;
    }
}
