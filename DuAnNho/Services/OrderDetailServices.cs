using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class OrderDetailServices : IAllServices<OrderDetailVM>
    {
        private readonly ApplicationBDContext _context;
        public OrderDetailServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public OrderDetailVM Add(OrderDetailVM item)
        {
            var existingDetail = _context.OrderDetails.FirstOrDefault(x => x.OrderId == item.OrderId && x.ProductId == item.ProductId);
            if (existingDetail != null)
            {
                existingDetail.Quantity += item.Quantity;
                existingDetail.Price += item.Price;
                _context.SaveChanges();

                return new OrderDetailVM
                {
                    Id = existingDetail.Id,
                    OrderId = existingDetail.OrderId,
                    ProductId = existingDetail.ProductId,
                    Price = existingDetail.Price,
                    Quantity = existingDetail.Quantity,
                    IsActive = existingDetail.IsActive
                };
            }
            else
            {

                var order = _context.Orders.FirstOrDefault(x => x.Id == item.OrderId);
                var product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);

                if (order != null && product != null)
                {
                    var newDetail = new OrderDetail
                    {
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        IsActive = item.IsActive,
                    };

                    _context.OrderDetails.Add(newDetail);
                    _context.SaveChanges();

                    var generatedId = newDetail.Id;

                    return new OrderDetailVM
                    {
                        Id = generatedId,
                        OrderId = newDetail.OrderId,
                        ProductId = newDetail.ProductId,
                        Price = newDetail.Price,
                        Quantity = newDetail.Quantity,
                        IsActive = newDetail.IsActive
                    };
                }
                else
                {

                    return null;
                }
            }
        }

        public void Delete(int id)
        {
            var detail = _context.OrderDetails.SingleOrDefault(x => x.Id == id);
            _context.OrderDetails.Remove(detail);
            _context.SaveChanges();
        }

        public List<OrderDetailVM> GetAll()
        {
            var detail = _context.OrderDetails.Select(x => new OrderDetailVM
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Price = x.Price,
                Quantity = x.Quantity,
                IsActive = x.IsActive
            });
            return detail.ToList();
        }

        public OrderDetailVM GetById(int id)
        {
            var detail = _context.OrderDetails.SingleOrDefault(x => x.Id == id);
            if (detail != null)
            {
                return new OrderDetailVM
                {
                    Id = detail.Id,
                    OrderId = detail.OrderId,
                    ProductId = detail.ProductId,
                    Price = detail.Price,
                    Quantity = detail.Quantity,
                    IsActive = detail.IsActive
                };
            }
            return null;
        }

        public void Update(OrderDetailVM item)
        {
            var detail = _context.OrderDetails.SingleOrDefault(x => x.Id == item.Id);
            detail.OrderId = detail.OrderId;
            detail.ProductId = detail.ProductId;
            detail.Price = detail.Price;
            detail.Quantity = detail.Quantity;
            detail.IsActive = detail.IsActive;
            _context.OrderDetails.Update(detail);
            _context.SaveChanges();
        }

    }
}
