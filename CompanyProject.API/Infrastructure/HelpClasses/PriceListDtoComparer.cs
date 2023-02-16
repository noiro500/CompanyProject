using CompanyProject.API.Infrastructure.Dto;

namespace CompanyProject.API.Infrastructure.HelpClasses;

//Класс необходим для удаления повторяющихся элементов в последовательности объектов
//с помощью Distinct()
public class PriceListDtoComparer : IEqualityComparer<PriceListDto>
{
    public bool Equals(PriceListDto x, PriceListDto y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.IdServiceName == y.IdServiceName;
    }

    public int GetHashCode(PriceListDto obj)
    {
        return obj.IdServiceName != null ? obj.IdServiceName.GetHashCode() : 0;
    }
}