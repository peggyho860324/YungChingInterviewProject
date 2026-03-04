namespace YungChingInterviewProject.DTOs.Order
{
    public class CreateOrderRequest
    {
        public required string CustomerId { get; set; }
        public required string EmployeeId { get; set; }
        public required string ShipVia { get; set; }
        public required string ShipAddress { get; set; }
    }
}
