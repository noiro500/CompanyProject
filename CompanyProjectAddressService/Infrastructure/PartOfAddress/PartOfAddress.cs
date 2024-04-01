using CompanyProjectAddressService.Model;
using System.Text;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using System.Reflection.Metadata;

namespace CompanyProjectAddressService.Infrastructure.PartOfAddress
{
    public class PartOfAddress : IPartOfAddress
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartOfAddress(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<string>> GetAddressPart(string ident, string selectedParam)
        {
            if (string.IsNullOrWhiteSpace(ident))
                return null;
            IList<string>? result = new List<string>();
            var repository = _unitOfWork.Repository<AddressInDb>();
            if (ident == "District")
            {
                var query = repository.MultipleResultQuery()
                    .AndFilter(p => p.IsUsedInDistrict == true)
                    .OrderBy(p => p.Offname)
                    .Select(m => m.Offname);
                result = await repository.SearchAsync(query);
            }
            else if (ident == "PopulatedArea")
            {
                var guid=repository.SingleResultQuery()
                    .AndFilter(p => (p.Offname == selectedParam && p.Aolevel==3))
                    .Select(s=>s.Aoguid);
                var districtAoguid = await repository.FirstOrDefaultAsync(guid);
                var populatedAreasList = repository.MultipleResultQuery()
                    .AndFilter(a => a.Parentguid == districtAoguid && (a.Aolevel == 6 || a.Aolevel == 4))
                    .Select(p => p.Offname)
                    .OrderBy(p => p.Offname);
               result = await repository.SearchAsync(populatedAreasList);
            }
            else if (ident == "Street")
            {
                var guid = repository.SingleResultQuery()
                    .AndFilter(p => p.Offname == selectedParam && (p.Aolevel == 6 || p.Aolevel == 4))
                    .Select(s => s.Aoguid);
                var populatedAreaAoguid = await repository.FirstOrDefaultAsync(guid);
                var streetList = repository.MultipleResultQuery()
                    .AndFilter(a => a.Parentguid == populatedAreaAoguid && a.Aolevel == 7)
                    .Select(p => p.Offname)
                    .OrderBy(p => p.Offname);
                result = await repository.SearchAsync(streetList);
            }
            if (result is null)
                return null;
            return result;
        }

    }
}
