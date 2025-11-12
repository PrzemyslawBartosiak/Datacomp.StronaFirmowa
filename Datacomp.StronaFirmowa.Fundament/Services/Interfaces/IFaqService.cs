using Datacomp.StronaFirmowa.Fundament.Models.Entities;

namespace Datacomp.StronaFirmowa.Fundament.Services.Interfaces
{
    public interface IFaqSerwis
    {
        Task<List<Faq>> PobierzWszystkieAsync(string jezyk);
        Task<Faq?> PobierzPoIdAsync(int id);
        Task<Faq> UtworzAsync(Faq faq);
        Task AktualizujAsync(Faq faq);
        Task UsunAsync(int id);
    }
}
