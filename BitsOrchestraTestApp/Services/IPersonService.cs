using BitsOrchestraTestApp.Dtos;
using BitsOrchestraTestApp.Models;

namespace BitsOrchestraTestApp.Services
{
    public interface IPersonService
    {
        Task UploadPersonsFromCsvAsync(Stream csvStream);
        Task<List<PersonDto>> GetAllPersonsAsync();
        Task EditPersonAsync(PersonDto personDto);
        Task DeletePersonAsync(int id);
    }
}
