using Cars.DAL.Models;

namespace Cars.Core.Services.Interfaces
{
    public interface ISellerService
    {
        Seller GetById(int id);

        void UpdateSeller(Seller car);

        void DeleteSeller(Seller car);

        void AddSeller(Seller car);
    }
}
