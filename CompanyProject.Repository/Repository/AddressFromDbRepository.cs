using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFromDb;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository.Repository
{
    public class AddressFromDbRepository :GenericRepository<AddressFromDb>, IAddressFromDbRepository
    {
        //protected readonly CompanyProjectDbContext _context;
        public AddressFromDbRepository(CompanyProjectDbContext ctx):base(ctx)
        {
            //_context = ctx;
        }

        public async Task<IList<AddressFromDb>> GetUsedDistrictsAsync()
        {
            var districts = await _context.Set<AddressFromDb>()
                .Where(p => p.IsUsedInDistrict.Value == true).OrderBy(p => p.Offname).ToListAsync();
            return districts;
        }

        public async Task<IList<AddressFromDb>> GetWorkPopulatedAreaAsync(string district)
        {
            var districtAoguid = (await _context.Set<AddressFromDb>()
                .FirstOrDefaultAsync(p => (p.Offname == district && p.Aolevel == 3))).Aoguid;
            var populatedAreasList = await _context.Set<AddressFromDb>()
                .Where(a => (a.Parentguid == districtAoguid && (a.Aolevel == 6 | a.Aolevel == 4)))
                .OrderBy(p=>p.Offname).ToListAsync();
            return populatedAreasList;
        }

        public async Task<IList<AddressFromDb>> GetWorkStreetAsync(string populatedArea)
        {
            var populatedAreaAoguid= (await _context.Set<AddressFromDb>()
                .FirstOrDefaultAsync(p => (p.Offname == populatedArea && (p.Aolevel == 6 | p.Aolevel == 4)))).Aoguid;
            var streetList = await _context.Set<AddressFromDb>()
                .Where(a => (a.Parentguid == populatedAreaAoguid && a.Aolevel == 7  ))
                .OrderBy(p => p.Offname).ToListAsync();
            return streetList;
        }
    }
}
