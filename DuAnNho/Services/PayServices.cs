using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using System.Xml.Linq;

namespace DuAnNho.Services
{
    public class PayServices : IAllServices<PaymentMethodsVM>
    {
        private readonly ApplicationBDContext _context;
        public PayServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public PaymentMethodsVM Add(PaymentMethodsVM item)
        {

            var pay = new PaymentMethods
            {
                Name = item.Name,
                Description = item.Description,
            };
            _context.PaymentMethods.Add(pay);
            _context.SaveChanges();
            var generatedId = pay.Id;
            return new PaymentMethodsVM
            {
                Id = generatedId,
                Name = item.Name,
                Description = item.Description,
            };
        }

        public void Delete(int id)
        {
            var pay = _context.PaymentMethods.SingleOrDefault(x => x.Id == id);
            if (pay != null)
            {
                _context.PaymentMethods.Remove(pay);
                _context.SaveChanges();
            }
        }

        public List<PaymentMethodsVM> GetAll()
        {
            var pay = _context.PaymentMethods.Select(x => new PaymentMethodsVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            });
            return pay.ToList();
        }

        public PaymentMethodsVM GetById(int id)
        {
            var pay = _context.PaymentMethods.SingleOrDefault(x => x.Id == id);
            if (pay != null)
            {
                return new PaymentMethodsVM
                {
                    Id = pay.Id,
                    Name = pay.Name,
                    Description = pay.Description,
                };
            }
            return null;
        }

        public void Update(PaymentMethodsVM item)
        {
            var pay = _context.PaymentMethods.SingleOrDefault(x => x.Id == item.Id);

            pay.Name = item.Name;
            pay.Description = item.Description;

            _context.PaymentMethods.Update(pay);
            _context.SaveChanges();
        }
    }
}
