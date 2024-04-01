namespace CompanyProjectPriceListService.Model
{
    public record TypeOfFailure
    {
        public int Id { get; set; }
        public string Service { get; set; } = null!;
        public string ServiceName { get; set; }=null!;

    }
}
