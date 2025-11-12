using Datacomp.StronaFirmowa.Fundament.Models.Entities;

namespace Datacomp.StronaFirmowa.Fundament.Services.Interfaces
{
    public interface IAktualnosciSerwis
    {
        Task<List<Aktualnosc>> PobierzWszystkieOpublikowane(string jezyk, int ilosc = 5);
        Task<Aktualnosc?> PobierzPoIdAsync(int id);
        Task<Aktualnosc> UtworzAsync(Aktualnosc aktualnosc);
        Task AktualizujAsync(Aktualnosc aktualnosc);
        Task UsunAsync(int id);
        Task OpublikujAsync(int id);
    }
}
