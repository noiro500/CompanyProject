using CompanyProjectAddressService.Model;
using System.Text;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using System;

namespace CompanyProjectAddressService.Infrastructure.PartOfAddress
{
    public class PartOfAddress : IPartOfAddress
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartOfAddress(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<string>> GetPartOfAddress(IList<string> parameters)
        {
            if (!parameters.Any())
                return null;
            IList<string>? result = new List<string>();
            var repository = _unitOfWork.Repository<AddressInDb>();
            if (parameters[0] == "District")
            {
                var query = repository.MultipleResultQuery()
                    .AndFilter(p => p.IsUsedInDistrict == true)
                    .OrderBy(p => p.Offname)
                    .Select(m => m.Offname);
                result = await repository.SearchAsync(query);
            }
            else if (parameters[0] == "PopulatedArea")
            {
                var guid=repository.SingleResultQuery()
                    .AndFilter(p => (p.Offname == parameters[1] && p.Aolevel==3))
                    .Select(s=>s.Aoguid);
                var districtAoguid = await repository.FirstOrDefaultAsync(guid);
                var populatedAreasList = repository.MultipleResultQuery()
                    .AndFilter(a => a.Parentguid == districtAoguid && (a.Aolevel == 6 || a.Aolevel == 4))
                    .Select(p => p.Offname)
                    .OrderBy(p => p.Offname);
               result = await repository.SearchAsync(populatedAreasList);
            }
            else if (parameters[0] == "Street")
            {
                var guid = repository.SingleResultQuery()
                    .AndFilter(p => p.Offname == parameters[1] && (p.Aolevel == 6 || p.Aolevel == 4))
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

        public string HtmlPart(string partOfAddress, IList<string> offnameList)
        {
            var html=new StringBuilder();
            html.AppendLine($"<select name=\"{partOfAddress}\">");
            if(partOfAddress== "District")
                html.AppendLine($"<option disabled selected value=\"\">Выберите район/округ/городской округ</option>");
            else if(partOfAddress== "PopulatedArea")
                html.AppendLine($"<option disabled selected value=\"\">Выберите населенный пункт</option>");
            else if( partOfAddress== "Street")
                html.AppendLine($"<option disabled selected value=\"\">Выберите улицу/проспект/переулок</option>");
            foreach (var item in offnameList)
            {
                html.AppendLine($"<option value=\"{item}\">{item}</option>");
            }
            html.AppendLine("</select>");
            var a = html.ToString();
            return html.ToString();
        }
    }
}
