using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFormDb;

namespace CompanyProject.Repository.Repository
{
    class AddressFromDbRepository : IAddressFromDbRepository
    {
        protected readonly CompanyProjectDbContext _context;
        public AddressFromDbRepository(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }
        public Task<IList<AddressFormDb>> GetUsedDistrictsAsync(bool isUsed)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AddressFormDb>> GetWorkLocalityAsync(string districtAoguid)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AddressFormDb>> GetWorkStreetAsync(string locationAoguid)
        {
            throw new NotImplementedException();
        }
    }
}
