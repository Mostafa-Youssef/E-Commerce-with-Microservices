using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
