using Cars.DAL.Models;

namespace Cars.Core.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Car> Cars { get; }

        IRepository<Operation> Operations { get; }

        IRepository<CarBrand> CarBrands { get; }

        IRepository<Seller> Sellers { get; }
    }
}
