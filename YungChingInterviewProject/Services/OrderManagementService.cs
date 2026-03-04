using Microsoft.EntityFrameworkCore;
using YungChingInterviewProject.Data;
using YungChingInterviewProject.DTOs;
using YungChingInterviewProject.DTOs.Order;
using YungChingInterviewProject.Entities;

namespace YungChingInterviewProject.Services
{
    /// <summary>
    /// 客戶訂單管理服務
    /// </summary>
    public class OrderManagementService
    {
        private readonly AppDbContext _db;

        public OrderManagementService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>建立新訂單</summary>
        public async Task<BaseResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ShipVia))
                throw new ArgumentException("運送方式不可為空");

            if (string.IsNullOrWhiteSpace(request.ShipAddress))
                throw new ArgumentException("運送地址不可為空");

            var order = new Order
            {
                CustomerID = request.CustomerId,
                EmployeeID = int.Parse(request.EmployeeId),
                ShipVia = int.Parse(request.ShipVia),
                ShipAddress = request.ShipAddress
            };

            _db.Orders.Add(order);

            await _db.SaveChangesAsync();

            return new BaseResponse { Code = "OM_001", Messgae = "訂單新增成功" };
        }

        /// <summary>查詢訂單</summary>
        public async Task<BaseResponse> QueryOrderAsync(QueryOrderRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CustomerId))
                throw new ArgumentException("客戶ID不可為空");

            var orderList = await _db.Orders.Where(x => x.CustomerID == request.CustomerId).ToListAsync();
            var items = orderList.Select(x =>
                new QueryOrderResponse
                {
                    OrderID = x.OrderID,
                    CustomerID = x.CustomerID,
                    CustomerName = "客戶姓名", // TODO: 需另查詢客戶基本資料
                    EmployeeID = x.EmployeeID,
                    EmployeeName = "員工姓名", // TODO: 需另查詢員工基本資料
                    OrderDate = x.OrderDate,
                    RequiredDate = x.RequiredDate,
                    ShippedDate = x.ShippedDate,
                    ShipVia = x.ShipVia,
                    ShipViaName = "", // TODO: 需另查詢貨運基本資料
                    Freight = x.Freight,
                    ShipName = x.ShipName,
                    ShipAddress = x.ShipAddress
                }
            ).ToList();

            return new BaseResponse { Code = "OM_002", Messgae = "查詢新增成功", Data = items };
        }
    }
}
