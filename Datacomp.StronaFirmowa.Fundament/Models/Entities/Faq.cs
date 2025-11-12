namespace Datacomp.StronaFirmowa.Fundament.Models.Entities
{
    public class Faq
    {
        public int Id { get; set; }
        public string Pytanie { get; set; } = string.Empty;
        public string Odpowiedz { get; set; } = string.Empty;
        public string Jezyk { get; set; } = "pl-PL"; // pl-PL, en-US, uk-UA
        public int Kolejnosc { get; set; }
        public bool CzyAktywny { get; set; } = true;
        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;
        public DateTime? DataAktualizacji { get; set; }
    }
}
