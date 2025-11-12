namespace Datacomp.StronaFirmowa.Fundament.Models.Entities
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string HashHasla { get; set; } = string.Empty;
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string Rola { get; set; } = "Uzytkownik"; // Uzytkownik, Administrator
        public bool CzyAktywny { get; set; } = true;
        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;
        public DateTime? DataOstatniegLogowania { get; set; }
    }
}
