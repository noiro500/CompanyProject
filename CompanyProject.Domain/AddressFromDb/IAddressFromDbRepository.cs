using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.Domain.AddressFromDb
{
    public interface IAddressFromDbRepository
    {
        public Task<IList<AddressFormDb.AddressFromDb>> GetUsedDistrictsAsync(bool isUsed);
        public Task<IList<AddressFormDb.AddressFromDb>> GetWorkLocalityAsync(string districtAoguid);
        public Task<IList<AddressFormDb.AddressFromDb>> GetWorkStreetAsync(string locationAoguid);
    }
}
