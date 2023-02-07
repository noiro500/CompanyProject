﻿namespace CompanyProjectAddressService.Model
{
    public class AddressInDb
    {
        public int AddressInDbId { get; set; }
        public int Actstatus { get; set; }
        public string Aoguid { get; set; }
        public int Aolevel { get; set; }
        public string Formalname { get; set; }
        public string Offname { get; set; }
        public string Parentguid { get; set; }
        public int Regioncode { get; set; }
        public bool? IsUsedInDistrict { get; set; } = null;
    }
}
