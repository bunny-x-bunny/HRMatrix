using HRMatrix.Application.DTOs.OrderWorkType;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services {
    public class OrderWorkTypeService : IOrderWorkTypeService {
        private readonly HRMatrixDbContext _context;

        public OrderWorkTypeService(HRMatrixDbContext context) {
            _context = context;
        }

        //public async Task<List<OrderWorkTypeResponse>> GetOrderWorkTypes(Order order) {
        //}

        public async Task<int> CreateOrderWorkType(CreateOrderWorkTypeRequest workTypeDto, Order order, bool withSave = false) {
            var workType = new OrderWorkType {
                OrderId = order.Id,
                WorkTypeId = workTypeDto.WorkTypeId
            };
            _context.OrderWorkTypes.Add(workType);
            if (withSave)
                await _context.SaveChangesAsync();
            return workType.Id;
        }

        public async Task<List<int>> UpsertOrderWorkTypes(CreateOrderWorkTypesRequest workTypesDto, bool withSave = false) {
            var order = await _context.Orders.FindAsync(workTypesDto.orderId);
            if (order == null) {
                throw new Exception($"Order with ID {workTypesDto.orderId} not found.");
            }

            var existingWorkTypes = await _context.OrderWorkTypes
                .Where(wt => wt.OrderId == workTypesDto.orderId)
                .ToListAsync();
            _context.OrderWorkTypes.RemoveRange(existingWorkTypes);

            var newWorkTypes = workTypesDto.WorkTypes.Select(wt => new OrderWorkType {
                OrderId = workTypesDto.orderId,
                WorkTypeId = wt.WorkTypeId,
            }).ToList();

            _context.OrderWorkTypes.AddRange(newWorkTypes);

            if (withSave) {
                await _context.SaveChangesAsync();
                return order.OrderWorkTypes.Select(wt => wt.Id).ToList();
            }
            else {
                return Enumerable.Empty<int>().ToList();
            }
        }

        public async Task<bool> DeleteOrderWorkType(int orderWorkTypeId, bool withSave = false) {
            var workType = await _context.OrderWorkTypes.FindAsync(orderWorkTypeId);
            if (workType == null) return false;

            _context.OrderWorkTypes.Remove(workType);
            if (withSave)
                await _context.SaveChangesAsync();
            return true;
        }
    }
}
