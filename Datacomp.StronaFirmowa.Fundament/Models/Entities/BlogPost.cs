namespace Datacomp.StronaFirmowa.Fundament.Models.Entities
{
    public class WpisBlog
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Tresc { get; set; } = string.Empty;
        public string Streszczenie { get; set; } = string.Empty;
        public string? UrlObrazka { get; set; }
        public string Jezyk { get; set; } = "pl-PL";
        public bool CzyOpublikowany { get; set; } = false;
        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;
        public DateTime? DataPublikacji { get; set; }
        public DateTime? DataAktualizacji { get; set; }
        public string? NazwiskoAutora { get; set; }
        public string? MetaOpis { get; set; }
        public string? Tagi { get; set; } // Oddzielone przecinkami
    }
}
