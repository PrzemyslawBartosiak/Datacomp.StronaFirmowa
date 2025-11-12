using Datacomp.StronaFirmowa.Fundament.Models.Entities;

namespace Datacomp.StronaFirmowa.Fundament.Services.Interfaces
{
    public interface IBlogSerwis
    {
        Task<List<WpisBlog>> PobierzWszystkieOpublikowane(string jezyk, int numerStrony = 1, int rozmiarStrony = 10);
        Task<WpisBlog?> PobierzPoSlugu(string slug, string jezyk);
        Task<WpisBlog?> PobierzPoIdAsync(int id);
        Task<WpisBlog> UtworzAsync(WpisBlog wpisBlog);
        Task AktualizujAsync(WpisBlog wpisBlog);
        Task UsunAsync(int id);
        Task OpublikujAsync(int id);
    }
}
