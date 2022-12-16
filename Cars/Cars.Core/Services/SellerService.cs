using Cars.Core.Repository;
using Cars.Core.Services.Interfaces;
using Cars.DAL.Models;

namespace Cars.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddSeller(Seller car)
        {
            _unitOfWork.Sellers.Add(car);
        }

        public void DeleteSeller(Seller seller)
        {
            _unitOfWork.Sellers.Delete(seller);
        }

        public Seller GetById(int id)
        {
            return _unitOfWork.Sellers
                .GetBy(c => c.Id == id)
                .FirstOrDefault();
        }

        public void UpdateSeller(Seller seller)
        {
            _unitOfWork.Sellers.Update(seller);
        }
    }
}
