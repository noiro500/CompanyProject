using System.Text;
using System.Text.Json;

namespace CompanyProjectAddressService.Infrastructure.GetPartOfAddress
{
    public class PartOfAddress : IPartOfAddress
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private Dictionary<string, string> _partOfAddresses;

        public PartOfAddress(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "HtmlData",
                "PartOfAddressData.json");
            _partOfAddresses = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(filePath));
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
