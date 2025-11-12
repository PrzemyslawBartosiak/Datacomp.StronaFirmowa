using Datacomp.StronaFirmowa.Fundament.Models.DTOs;
using Datacomp.StronaFirmowa.Fundament.Models.Entities;

namespace Datacomp.StronaFirmowa.Fundament.Services.Interfaces
{
    public interface IAutentykacjaSerwis
    {
        Task<Uzytkownik?> UwierzytelnijAsync(DaneLogowaniaDto daneLogowania);
        Task<Uzytkownik> ZarejestrujAsync(string email, string haslo, string? imie, string? nazwisko);
        Task<bool> WalidujHasloAsync(string haslo, string hashHasla);
        string HashujHaslo(string haslo);
    }
}
