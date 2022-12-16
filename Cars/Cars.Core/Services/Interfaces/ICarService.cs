using Cars.DAL.Models;

namespace Cars.Core.Services.Interfaces
{
    public interface ICarService
    {
        Car GetById(int id);

        void UpdateCar(Car car);

        void DeleteCar(Car car);

        void AddCar(Car car);
    }
}
