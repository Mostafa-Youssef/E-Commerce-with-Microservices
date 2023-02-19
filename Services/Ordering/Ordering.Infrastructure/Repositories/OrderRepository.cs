using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Order>> GetOdersByUserName(string userName)
        {
            var orderList = await _context.orders.Where(x => x.UserName == userName).ToListAsync();
            return orderList;
        }
    }
}
