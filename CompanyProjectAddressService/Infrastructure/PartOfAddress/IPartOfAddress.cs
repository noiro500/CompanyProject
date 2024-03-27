namespace CompanyProjectAddressService.Infrastructure.PartOfAddress
{
    public interface IPartOfAddress
    {
        public Task<IList<string>> GetAddressPart(string parameter, string selectedParam);

    }
}
