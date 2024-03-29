﻿using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository: IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOdersByUserName(string userName);
    }
}
