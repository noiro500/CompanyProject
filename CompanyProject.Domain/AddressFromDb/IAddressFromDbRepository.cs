using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.Domain.AddressFromDb
{
    public interface IAddressFromDbRepository
    {
        public Task<IList<AddressFromDb>> GetUsedDistrictsAsync();
        public Task<IList<AddressFromDb>> GetWorkPopulatedAreaAsync(string districtAoguid);
        public Task<IList<AddressFromDb>> GetWorkStreetAsync(string locationAoguid);
        //public Task<IList<AddressFromDb>> GetAddressStringFromDbAsync(string parameter);

    }
}
