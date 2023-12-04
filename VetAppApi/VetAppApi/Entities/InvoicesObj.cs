namespace VetAppApi.Entities
{
    public class InvoicesObj
    {
        public int idInvoices { get; set; } = 0;
        public long numReference { get; set; }
        public DateTime dateInvoices { get; set; }
        public decimal totalCancel { get; set; }
        public decimal totalCanceled { get; set; }
        public int idPayment { get; set; }
        public int idClient { get; set; }
    }
}
