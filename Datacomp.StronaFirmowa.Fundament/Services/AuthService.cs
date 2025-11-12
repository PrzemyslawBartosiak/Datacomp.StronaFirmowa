using Datacomp.StronaFirmowa.Fundament.Data;
using Datacomp.StronaFirmowa.Fundament.Models.DTOs;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;
using Datacomp.StronaFirmowa.Fundament.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datacomp.StronaFirmowa.Fundament.Services
{
    public class AutentykacjaSerwis : IAutentykacjaSerwis
    {
        private readonly ApplicationDbContext _context;

        public AutentykacjaSerwis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Uzytkownik?> UwierzytelnijAsync(DaneLogowaniaDto daneLogowania)
        {
            var uzytkownik = await _context.Uzytkownicy
                .FirstOrDefaultAsync(u => u.Email == daneLogowania.Email && u.CzyAktywny);

            if (uzytkownik == null)
                return null;

            // Sprawdzenie has³a
            if (!await WalidujHasloAsync(daneLogowania.Haslo, uzytkownik.HashHasla))
                return null;

            uzytkownik.DataOstatniegLogowania = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return uzytkownik;
        }

        public async Task<Uzytkownik> ZarejestrujAsync(string email, string haslo, string? imie, string? nazwisko)
        {
            var istniejacyUzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(u => u.Email == email);
            if (istniejacyUzytkownik != null)
                throw new InvalidOperationException("U¿ytkownik z tym emailem ju¿ istnieje");

            var uzytkownik = new Uzytkownik
            {
                Email = email,
                HashHasla = HashujHaslo(haslo),
                Imie = imie,
                Nazwisko = nazwisko,
                DataUtworzenia = DateTime.UtcNow
            };

            _context.Uzytkownicy.Add(uzytkownik);
            await _context.SaveChangesAsync();
            return uzytkownik;
        }

        public Task<bool> WalidujHasloAsync(string haslo, string hashHasla)
        {
            // TODO: Implementacja z BCrypt.Net - dodaæ package: BCrypt.Net-Next
            // return Task.FromResult(BCrypt.Net.BCrypt.Verify(haslo, hashHasla));
            
            // TYMCZASOWO - prosty string porównanie (NIE U¯YWAÆ W PRODUKCJI!)
            return Task.FromResult(HashujHaslo(haslo) == hashHasla);
        }

        public string HashujHaslo(string haslo)
        {
            // TODO: Implementacja z BCrypt.Net - dodaæ package: BCrypt.Net-Next
            // return BCrypt.Net.BCrypt.HashPassword(haslo);
            
            // TYMCZASOWO - Base64 encoding (NIE U¯YWAÆ W PRODUKCJI!)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(haslo));
        }
    }
}
