using Datacomp.StronaFirmowa.Fundament.Data;
using Datacomp.StronaFirmowa.Fundament.Models.DTOs;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;
using Datacomp.StronaFirmowa.Fundament.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datacomp.StronaFirmowa.Fundament.Services
{
    public class KontaktSerwis : IKontaktSerwis
    {
        private readonly ApplicationDbContext _context;

        public KontaktSerwis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WiadomoscKontaktowa> WyslijWiadomoscAsync(FormularzKontaktowyDto dto)
        {
            var wiadomosc = new WiadomoscKontaktowa
            {
                Imie = dto.Imie,
                Email = dto.Email,
                Telefon = dto.Telefon,
                Temat = dto.Temat,
                Wiadomosc = dto.Wiadomosc,
                DataUtworzenia = DateTime.UtcNow
            };

            _context.WiadomosciKontaktowe.Add(wiadomosc);
            await _context.SaveChangesAsync();
            return wiadomosc;
        }

        public async Task<List<WiadomoscKontaktowa>> PobierzWszystkieWiadomosciAsync()
        {
            return await _context.WiadomosciKontaktowe
                .OrderByDescending(m => m.DataUtworzenia)
                .ToListAsync();
        }

        public async Task<WiadomoscKontaktowa?> PobierzPoIdAsync(int id)
        {
            return await _context.WiadomosciKontaktowe.FindAsync(id);
        }

        public async Task OznaczJakoPrzeczytanaAsync(int id)
        {
            var wiadomosc = await _context.WiadomosciKontaktowe.FindAsync(id);
            if (wiadomosc != null)
            {
                wiadomosc.CzyPrzeczytana = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UsunAsync(int id)
        {
            var wiadomosc = await _context.WiadomosciKontaktowe.FindAsync(id);
            if (wiadomosc != null)
            {
                _context.WiadomosciKontaktowe.Remove(wiadomosc);
                await _context.SaveChangesAsync();
            }
        }
    }
}
