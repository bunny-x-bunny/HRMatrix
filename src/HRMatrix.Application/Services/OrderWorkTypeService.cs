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

        public async Task<List<int>> CreateOrderWorkTypes(List<int> workTypes, Order order, bool withSave = false) {
            order.OrderWorkTypes = workTypes.Select(wt => new OrderWorkType {
                OrderId = order.Id,
                WorkTypeId = wt,
            }).ToList();

            if (withSave) {
                await _context.SaveChangesAsync();
                return order.OrderWorkTypes.Select(wt => wt.Id).ToList();
            }
            else {
                return Enumerable.Empty<int>().ToList();
            }
        }

        public async Task<List<int>> UpdateOrderWorkTypes(List<int> workTypes, Order order, bool withSave = false) {
            var existingWorkTypes = await _context.OrderWorkTypes
                .Where(wt => wt.OrderId == order.Id)
                .ToListAsync();
            _context.OrderWorkTypes.RemoveRange(existingWorkTypes);

            order.OrderWorkTypes = workTypes.Select(wt => new OrderWorkType {
                OrderId = order.Id,
                WorkTypeId = wt,
            }).ToList();

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
