using Cars.Core.Repository;
using Cars.Core.Services.Interfaces;
using Cars.DAL.Models;

namespace Cars.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCar(Car car)
        {
            _unitOfWork.Cars.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _unitOfWork.Cars.Delete(car);
        }

        public Car GetById(int id)
        {
            return _unitOfWork.Cars
                .GetBy(c => c.Id == id)
                .FirstOrDefault();
        }

        public void UpdateCar(Car car)
        {
            _unitOfWork.Cars.Update(car);
        }
    }
}
