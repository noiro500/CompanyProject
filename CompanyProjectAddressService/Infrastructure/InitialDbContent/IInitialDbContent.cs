namespace CompanyProjectAddressService.Infrastructure.InitialDbContent
{
    public interface IInitialDbContent
    {
        IList<T> InitialContent<T>(string jsonFile) where T : new();
    }
}
