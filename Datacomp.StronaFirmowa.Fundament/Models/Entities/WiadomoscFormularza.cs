namespace Datacomp.StronaFirmowa.Fundament.Models.Entities
{
    public class WiadomoscKontaktowa
    {
        public int Id { get; set; }
        public string Imie { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public string Temat { get; set; } = string.Empty;
        public string Wiadomosc { get; set; } = string.Empty;
        public bool CzyPrzeczytana { get; set; } = false;
        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;
        public string? NotatkaAdministratora { get; set; }
    }
}
