namespace YungChingInterviewProject.DTOs.Order
{
    public class QueryOrderResponse
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public int? EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public string? ShipViaName { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
    }
}
