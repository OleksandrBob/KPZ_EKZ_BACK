using Cars.Core.Repository;
using Cars.Core.Services.Interfaces;
using Cars.DAL.Models;

namespace Cars.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CarBrand GetBrandByName(string name)
        {
            return _unitOfWork.CarBrands
                .GetBy(b => b.Name == name)
                .FirstOrDefault();
        }
    }
}
