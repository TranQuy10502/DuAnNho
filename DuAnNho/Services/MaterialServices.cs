using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;

namespace DuAnNho.Services
{
    public class MaterialServices : IAllServices<MaterialsVM>
    {
        private readonly ApplicationBDContext _context;
        public MaterialServices(ApplicationBDContext context)
        {
            _context = context;
        }

        public MaterialsVM Add(MaterialsVM item)
        {
            var material = new Materials
            {
                Name = item.Name,
                Description = item.Description,
               
            };
            _context.Materials.Add(material);
            _context.SaveChanges();
            var generatedId = material.Id;
            return new MaterialsVM
            {
                Id = generatedId,
                Name = item.Name,
                Description = item.Description,
                
            };
        }

        public void Delete(int id)
        {
            var material = _context.Materials.SingleOrDefault(x => x.Id == id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
        }

        public List<MaterialsVM> GetAll()
        {
            var material = _context.Materials.Select(x => new MaterialsVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
               
            });
            return material.ToList();
        }

        public MaterialsVM GetById(int id)
        {
            var material = _context.Materials.SingleOrDefault(_x => _x.Id == id);
            if (material != null)
            {
                return new MaterialsVM
                {
                    Id = material.Id,
                    Name = material.Name,
                    Description = material.Description,
                  
                };

            }
            return null;
        }

        public void Update(MaterialsVM item)
        {
            var marterial = _context.Materials.SingleOrDefault(x => x.Id != item.Id);

            marterial.Name = item.Name;
            marterial.Description = item.Description;
           
            _context.Materials.Update(marterial);
            _context.SaveChanges();
        }
    }
}
