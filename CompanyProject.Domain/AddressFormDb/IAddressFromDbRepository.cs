using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain.AddressFormDb
{
    public interface IAddressFromDbRepository
    {
        public Task<IList<AddressFormDb>> GetUsedDistrictsAsync(bool isUsed);
        public Task<IList<AddressFormDb>> GetWorkLocalityAsync(string districtAoguid);
        public Task<IList<AddressFormDb>> GetWorkStreetAsync(string locationAoguid);
    }
}
