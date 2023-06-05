namespace CompanyProjectAddressService.Infrastructure.PartOfAddress
{
    public interface IPartOfAddress
    {
        string HtmlPart(string partOfAddress, IList<string> offnameList);
        public Task<IList<string>> GetAddressPart(IList<string> parameters);

    }
}
