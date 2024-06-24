namespace hrms.Models
{
    public class Distributor
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string SerialNo { get; set; }

        public string CompanyCRN { get; set; }
    }
}
