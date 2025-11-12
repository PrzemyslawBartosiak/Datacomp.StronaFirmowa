using Datacomp.StronaFirmowa.Fundament.Data;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;
using Datacomp.StronaFirmowa.Fundament.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datacomp.StronaFirmowa.Fundament.Services
{
    public class BlogSerwis : IBlogSerwis
    {
        private readonly ApplicationDbContext _context;

        public BlogSerwis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WpisBlog>> PobierzWszystkieOpublikowane(string jezyk, int numerStrony = 1, int rozmiarStrony = 10)
        {
            return await _context.WpisyBlog
                .Where(b => b.CzyOpublikowany && b.Jezyk == jezyk)
                .OrderByDescending(b => b.DataPublikacji)
                .Skip((numerStrony - 1) * rozmiarStrony)
                .Take(rozmiarStrony)
                .ToListAsync();
        }

        public async Task<WpisBlog?> PobierzPoSlugu(string slug, string jezyk)
        {
            return await _context.WpisyBlog
                .FirstOrDefaultAsync(b => b.Slug == slug && b.Jezyk == jezyk && b.CzyOpublikowany);
        }

        public async Task<WpisBlog?> PobierzPoIdAsync(int id)
        {
            return await _context.WpisyBlog.FindAsync(id);
        }

        public async Task<WpisBlog> UtworzAsync(WpisBlog wpisBlog)
        {
            _context.WpisyBlog.Add(wpisBlog);
            await _context.SaveChangesAsync();
            return wpisBlog;
        }

        public async Task AktualizujAsync(WpisBlog wpisBlog)
        {
            wpisBlog.DataAktualizacji = DateTime.UtcNow;
            _context.Entry(wpisBlog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UsunAsync(int id)
        {
            var wpisBlog = await _context.WpisyBlog.FindAsync(id);
            if (wpisBlog != null)
            {
                _context.WpisyBlog.Remove(wpisBlog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task OpublikujAsync(int id)
        {
            var wpisBlog = await _context.WpisyBlog.FindAsync(id);
            if (wpisBlog != null)
            {
                wpisBlog.CzyOpublikowany = true;
                wpisBlog.DataPublikacji = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
