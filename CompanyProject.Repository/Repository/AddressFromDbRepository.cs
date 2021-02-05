using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFromDb;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository.Repository
{
    class AddressFromDbRepository : IAddressFromDbRepository
    {
        protected readonly CompanyProjectDbContext _context;
        public AddressFromDbRepository(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }

        //public async Task<IList<AddressFromDb>> GetAddressStringFromDbAsync(string parameter)
        //{
        //    return await _context.Set<AddressFromDb>().FindAsync(parameter);
        //}

        public async Task<IList<AddressFromDb>> GetUsedDistrictsAsync()
        {
            var districts = await _context.Set<AddressFromDb>().Where(p => p.IsUsedInDistrict.Value==true).ToListAsync();
            return districts;
        }

        public async Task<IList<AddressFromDb>> GetWorkPopulatedAreaAsync(string district)
        {
            var districtAoguid = (await _context.Set<AddressFromDb>()
                .FirstOrDefaultAsync(p => (p.Offname == district && p.Aolevel == 3))).Aoguid;
            var populatedAreas = (await _context.Set<AddressFromDb>()
                .Where(a => (a.Parentguid == districtAoguid && (a.Aolevel == 6 | a.Aolevel == 4)))
                .OrderBy(p=>p.Offname).ToListAsync());
            return populatedAreas.ToList();
        }

        public Task<IList<AddressFromDb>> GetWorkStreetAsync(string locationAoguid)
        {
            throw new NotImplementedException();
        }
    }
}
