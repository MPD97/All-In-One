using AOI_Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOI_Services.Services
{
    public interface IPersonRepository
    {
        Task<ICollection<Person>> GetAllAsync(string firstName = "", string lastName ="");
    }
}