using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Repository
{
	public class DepartamentRepository : IDepartamentRepository
    {
        private readonly DataContext _context;

        public DepartamentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Departament departament)
        {
            await _context.Departaments.AddAsync(departament);
            await _context.SaveChangesAsync();
        }

        public async Task<Departament> GetAsync(string name)
        {
            var departament = await _context.Departaments
                .FirstOrDefaultAsync(x => x.Name == name);

            return departament;
        }

        public async Task<IEnumerable<Departament>> GetAsync()
        {
            var departaments = await _context.Departaments.ToListAsync();

            return departaments;
        }
    }
}
