using Cars.DAL.Models;

namespace Cars.Core.Services.Interfaces
{
    public interface IBrandService
    {
        CarBrand GetBrandByName(string name);
    }
}
