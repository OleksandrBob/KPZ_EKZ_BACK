using Cars.DAL.Models;
using DAL;

namespace Cars.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppContext _context;

        private IRepository<Car> cars;
        private IRepository<Operation> operations;
        private IRepository<CarBrand> carBrands;
        private IRepository<Seller> sellers;

        public UnitOfWork(MyAppContext context)
        {
            _context = context;
        }

        public IRepository<Car> Cars => cars ??= new GenericRepository<Car>(_context);
        public IRepository<Operation> Operations => operations ??= new GenericRepository<Operation>(_context);
        public IRepository<CarBrand> CarBrands => carBrands ??= new GenericRepository<CarBrand>(_context);
        public IRepository<Seller> Sellers => sellers ??= new GenericRepository<Seller>(_context);
    }
}
