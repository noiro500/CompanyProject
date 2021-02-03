using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFormDb;
using CompanyProject.Domain.AddressFromDb;

namespace CompanyProject.Repository.Repository
{
    class AddressFromDbRepository : IAddressFromDbRepository
    {
        protected readonly CompanyProjectDbContext _context;
        public AddressFromDbRepository(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }
        public Task<IList<AddressFromDb>> GetUsedDistrictsAsync(bool isUsed)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AddressFromDb>> GetWorkLocalityAsync(string districtAoguid)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AddressFromDb>> GetWorkStreetAsync(string locationAoguid)
        {
            throw new NotImplementedException();
        }
    }
}
