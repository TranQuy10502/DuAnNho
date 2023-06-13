using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using System.Net;
using System.Web.Helpers;

namespace DuAnNho.Services
{
    public class CustomerServices : IAllServices<CustomerVM>
    {
        private readonly ApplicationBDContext _context;
        public CustomerServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public CustomerVM Add(CustomerVM item)
        {
            var khachHang = new Customer
            {
                 CustomerName = item.CustomerName,
                 Email = item.Email,
                 Address = item.Address,
                 Password = item.Password,
                 PhoneNumber=item.PhoneNumber,
                 Points = item.Points,
            };
            _context.Customers.Add(khachHang);
            _context.SaveChanges();
            var generatedId = khachHang.CustomerId;
            return new CustomerVM
            {
                CustomerId = generatedId,
                CustomerName = item.CustomerName,
                Email = item.Email,
                Address = item.Address,
                Password = item.Password,
                PhoneNumber = item.PhoneNumber,
                Points = item.Points,
            };
        }

        public void Delete(int id)
        {
            var khachHang = _context.Customers.SingleOrDefault(x => x.CustomerId == id);
            if (khachHang != null)
            {
                _context.Customers.Remove(khachHang);
                _context.SaveChanges();
            }
        }

        public List<CustomerVM> GetAll()
        {
            var khachHang = _context.Customers.Select(x => new CustomerVM
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                Email = x.Email,
                Address =x.Address,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                Points = x.Points,

            });
            return khachHang.ToList();
        }

        public CustomerVM GetById(int id)
        {
            var khachHang = _context.Customers.SingleOrDefault(x => x.CustomerId == id);
            if (khachHang != null)
            {
                return new CustomerVM
                {
                    CustomerId = khachHang.CustomerId,
                    CustomerName = khachHang.CustomerName,
                    Email = khachHang.Email,
                    Address = khachHang.Address,
                    Password = khachHang.Password,
                    PhoneNumber = khachHang.PhoneNumber,
                    Points = khachHang.Points,
                };
            }
            return null;
        }

        public void Update(CustomerVM item)
        {
            var khachHang = _context.Customers.SingleOrDefault(x => x.CustomerId == item.CustomerId);

            khachHang.CustomerName = item.CustomerName;
            khachHang.Email = item.Email;
            khachHang.Address = item.Address;
            khachHang.Password = item.Password;
            khachHang.PhoneNumber = item.PhoneNumber;
            khachHang.Points = item.Points;

            _context.Customers.Update(khachHang);
            _context.SaveChanges();
        }
    }
}
