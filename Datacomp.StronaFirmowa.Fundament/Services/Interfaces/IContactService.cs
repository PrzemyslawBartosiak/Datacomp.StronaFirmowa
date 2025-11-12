using Datacomp.StronaFirmowa.Fundament.Models.DTOs;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;

namespace Datacomp.StronaFirmowa.Fundament.Services.Interfaces
{
    public interface IKontaktSerwis
    {
        Task<WiadomoscKontaktowa> WyslijWiadomoscAsync(FormularzKontaktowyDto dto);
        Task<List<WiadomoscKontaktowa>> PobierzWszystkieWiadomosciAsync();
        Task<WiadomoscKontaktowa?> PobierzPoIdAsync(int id);
        Task OznaczJakoPrzeczytanaAsync(int id);
        Task UsunAsync(int id);
    }
}
