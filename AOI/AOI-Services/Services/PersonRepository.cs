using AOI_Core.Entites;
using AOI_Infrastructure.Npgsql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI_Services.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationContext _context;

        public PersonRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Person>> GetAllAsync(string firstName = "", string lastName = "")
        {
            var query = _context.Set<Person>()
               .AsNoTracking();

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(x => x.FirstName == firstName);
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(x => x.LastName == lastName);
            }
            return await query.Take(50).ToArrayAsync();
        }
    }
}
