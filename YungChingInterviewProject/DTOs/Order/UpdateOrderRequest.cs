namespace YungChingInterviewProject.DTOs.Order
{
    public class UpdateOrderRequest
    {
        public required string EmployeeId { get; set; }
        public required string ShipVia { get; set; }
        public required string ShipAddress { get; set; }
    }
}
