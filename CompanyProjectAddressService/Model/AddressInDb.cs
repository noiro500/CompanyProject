namespace CompanyProjectAddressService.Model
{
    public class AddressInDb
    {
        public int AddressInDbId { get; set; }
        public int Actstatus { get; set; }
        public string Aoguid { get; set; } = null!;
        public int Aolevel { get; set; }
        public string Formalname { get; set; } = null!;
        public string Offname { get; set; } = null!;
        public string Parentguid { get; set; } = null!;
        public int Regioncode { get; set; }
        public bool? IsUsedInDistrict { get; set; } = null;
    }
}
