using Datacomp.StronaFirmowa.Fundament.Data;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;
using Datacomp.StronaFirmowa.Fundament.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datacomp.StronaFirmowa.Fundament.Services
{
    public class AktualnosciSerwis : IAktualnosciSerwis
    {
        private readonly ApplicationDbContext _context;

        public AktualnosciSerwis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aktualnosc>> PobierzWszystkieOpublikowane(string jezyk, int ilosc = 5)
        {
            var teraz = DateTime.UtcNow;
            return await _context.Aktualnosci
                .Where(n => n.CzyOpublikowany 
                    && n.Jezyk == jezyk 
                    && (n.DataWygasniecia == null || n.DataWygasniecia > teraz))
                .OrderByDescending(n => n.DataPublikacji)
                .Take(ilosc)
                .ToListAsync();
        }

        public async Task<Aktualnosc?> PobierzPoIdAsync(int id)
        {
            return await _context.Aktualnosci.FindAsync(id);
        }

        public async Task<Aktualnosc> UtworzAsync(Aktualnosc aktualnosc)
        {
            _context.Aktualnosci.Add(aktualnosc);
            await _context.SaveChangesAsync();
            return aktualnosc;
        }

        public async Task AktualizujAsync(Aktualnosc aktualnosc)
        {
            aktualnosc.DataAktualizacji = DateTime.UtcNow;
            _context.Entry(aktualnosc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UsunAsync(int id)
        {
            var aktualnosc = await _context.Aktualnosci.FindAsync(id);
            if (aktualnosc != null)
            {
                _context.Aktualnosci.Remove(aktualnosc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task OpublikujAsync(int id)
        {
            var aktualnosc = await _context.Aktualnosci.FindAsync(id);
            if (aktualnosc != null)
            {
                aktualnosc.CzyOpublikowany = true;
                aktualnosc.DataPublikacji = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
