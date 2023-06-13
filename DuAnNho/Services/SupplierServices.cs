using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class SupplierServices : IAllServices<SupplierVM>
    {
        private readonly ApplicationBDContext _context;

        public SupplierServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public SupplierVM Add(SupplierVM item)
        {
            var supplier = new Supplier
            {
                Name = item.Name,
                Description = item.Description,
                Email = item.Email,
                Phone = item.Phone,
                Detail = item.Detail
            };

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return new SupplierVM
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                Description = supplier.Description,
                Email = supplier.Email,
                Phone = supplier.Phone,
                Detail = supplier.Detail
            };
        }

        public void Delete(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(x => x.SupplierId == id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

        public List<SupplierVM> GetAll()
        {
            var suppliers = _context.Suppliers.Select(x => new SupplierVM
            {
                SupplierId = x.SupplierId,
                Name = x.Name,
                Description = x.Description,
                Email = x.Email,
                Phone = x.Phone,
                Detail = x.Detail
            }).ToList();

            return suppliers;
        }

        public SupplierVM GetById(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            if (supplier != null)
            {
                return new SupplierVM
                {
                    SupplierId = supplier.SupplierId,
                    Name = supplier.Name,
                    Description = supplier.Description,
                    Email = supplier.Email,
                    Phone = supplier.Phone,
                    Detail = supplier.Detail
                };
            }
            return null;
        }

        public void Update(SupplierVM item)
        {
            var supplier = _context.Suppliers.FirstOrDefault(x => x.SupplierId == item.SupplierId);
            if (supplier != null)
            {
                supplier.Name = item.Name;
                supplier.Description = item.Description;
                supplier.Email = item.Email;
                supplier.Phone = item.Phone;
                supplier.Detail = item.Detail;

                _context.SaveChanges();
            }
        }

    }
}
