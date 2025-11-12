using Datacomp.StronaFirmowa.Fundament.Data;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;
using Datacomp.StronaFirmowa.Fundament.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datacomp.StronaFirmowa.Fundament.Services
{
    public class FaqSerwis : IFaqSerwis
    {
        private readonly ApplicationDbContext _context;

        public FaqSerwis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Faq>> PobierzWszystkieAsync(string jezyk)
        {
            return await _context.Faq
                .Where(f => f.CzyAktywny && f.Jezyk == jezyk)
                .OrderBy(f => f.Kolejnosc)
                .ToListAsync();
        }

        public async Task<Faq?> PobierzPoIdAsync(int id)
        {
            return await _context.Faq.FindAsync(id);
        }

        public async Task<Faq> UtworzAsync(Faq faq)
        {
            _context.Faq.Add(faq);
            await _context.SaveChangesAsync();
            return faq;
        }

        public async Task AktualizujAsync(Faq faq)
        {
            faq.DataAktualizacji = DateTime.UtcNow;
            _context.Entry(faq).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UsunAsync(int id)
        {
            var faq = await _context.Faq.FindAsync(id);
            if (faq != null)
            {
                _context.Faq.Remove(faq);
                await _context.SaveChangesAsync();
            }
        }
    }
}
