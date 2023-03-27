using CompanyProjectAddressService.Model;
using System.Text;
using System.Text.Json;
using CompanyProjectAddressService.Infrastructure.PartOfAddress;
using EntityFrameworkCore.UnitOfWork.Interfaces;

namespace CompanyProjectAddressService.Infrastructure.PartOfAddress
{
    public class PartOfAddress : IPartOfAddress
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartOfAddress(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<string> GetPartOfAddress(IList<string> parameters)
        {
            if (!parameters.Any())
                return new List<string>{"Ошибка в получении части адреса"};
            IList<string>? result = new List<string>();
            var repository = _unitOfWork.Repository<AddressInDb>();
        }

        public string HtmlPart(string partOfAddress, IList<string> offnameList)
        {
            var html=new StringBuilder();
            html.AppendLine($"<select name=\"{partOfAddress}\">");
            html.AppendLine($"<option disabled selected value=\"\">{_partOfAddresses[partOfAddress]}</option>");
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
