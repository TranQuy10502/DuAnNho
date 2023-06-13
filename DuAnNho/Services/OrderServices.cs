using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class OrderServices : IAllServices<OrderVM>
    {
        private readonly ApplicationBDContext _context;
        public OrderServices(ApplicationBDContext context)
        {
            _context = context;
        }


        public OrderVM Add(OrderVM item)
        {
            var order = new Order
            {
                Code = item.Code,
                Phone = item.Phone,
                Address = item.Address,
                TotalAmount = item.TotalAmount,
                Quantity = item.Quantity,
                PaymentMethodId = item.PaymentMethodId,
                CustomerId = item.CustomerId,
                UserId = item.UserId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            var generatedId = order.Id;
            return new OrderVM
            {
                Id = generatedId,
                Code = item.Code,
                Phone = item.Phone,
                Address = item.Address,
                TotalAmount = item.TotalAmount,
                Quantity = item.Quantity,
                PaymentMethodId = item.PaymentMethodId,
                CustomerId = item.CustomerId,
                UserId = item.UserId,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate
            };
        }

        public void Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public List<OrderVM> GetAll()
        {
            var order = _context.Orders.Select(x => new OrderVM
            {
                
                Id = x.Id,
                Code = x.Code,
                Phone = x.Phone,
                Address = x.Address,
                TotalAmount = x.TotalAmount,
                Quantity = x.Quantity,
                PaymentMethodId = x.PaymentMethodId,
                CustomerId = x.CustomerId,
                UserId = x.UserId,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            });
            return order.ToList();
        }

        public OrderVM GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order != null)
            {
                return new OrderVM
                {
                    Id = order.Id,
                    Code = order.Code,
                    Phone = order.Phone,
                    Address = order.Address,
                    TotalAmount = order.TotalAmount,
                    Quantity = order.Quantity,
                    PaymentMethodId = order.PaymentMethodId,
                    CustomerId = order.CustomerId,
                    UserId = order.CustomerId,
                    CreatedDate = order.CreatedDate,
                     ModifiedDate = order.ModifiedDate
            };
            }
            return null;
        }

        public void Update(OrderVM item)
        {
            var order = _context.Orders.SingleOrDefault(x =>x.Id == item.Id);


            order.Code = item.Code;
            order.Phone = item.Phone;
            order.Address = item.Address;
            order.TotalAmount = item.TotalAmount;
            order.Quantity = item.Quantity;
            order.PaymentMethodId = item.PaymentMethodId;
            order.CustomerId = item.CustomerId;
            order.UserId = item.UserId;
            order.CreatedDate = item.CreatedDate;
            order.ModifiedDate = item.ModifiedDate;

            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
