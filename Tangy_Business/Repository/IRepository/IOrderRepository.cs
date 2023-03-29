
using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<OrderDTO> Get(int orderId);
        Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null);
        Task<OrderDTO> Create(OrderDTO orderDTO);
        Task<int> Delete(int id);
        Task<OrderHeaderDTO> UpdateHeader(OrderHeaderDTO orderHeaderDTO);
        Task<OrderHeaderDTO> MarkPaymentSuccessful(int id);
        Task<bool> UpdateOrderStatus(int orderId, string status);

    }
}
