namespace computershopAPI.Dtos.CartDtos
{
    public class HistoryPriceDto
    {
        public List<PurchaseHistory> HistoryItems { get; set; }
        public double Total { get; set; }
    }
}
