namespace CompanyProjectAddressService.Infrastructure.GetPartOfAddress
{
    public interface IPartOfAddress
    {
        string HtmlPart(string partOfAddress, IList<string> offnameList);
    }
}
