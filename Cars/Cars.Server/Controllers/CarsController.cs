using Cars.Core.Constants;
using Cars.Core.Services.Interfaces;
using Cars.DAL.Models;
using Cars.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly ISellerService _sellerService;
        private readonly IOperationService _operationService;

        public CarsController(
            ICarService carService,
            IBrandService brandService,
            ISellerService sellerService,
            IOperationService operationService)
        {
            _carService = carService;
            _brandService = brandService;
            _sellerService = sellerService;
            _operationService = operationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetById(id);

            if (car is null)
            {
                return BadRequest("Car do not exist");
            }

            CarDto dtoToReturn = new()
            {
                Brand = car.Brand?.Name,
                Id = car.Id,
                ModelName = car.ModelName,
                Price = car.Price,
                SoldTime = car.SoldTime,
            };

            return Ok(dtoToReturn);
        }

        [HttpPost]
        public IActionResult AddCar(UpdateCarDto dto)
        {
            CarBrand brand = _brandService.GetBrandByName(dto.BrandName);

            if (brand is null)
            {
                return BadRequest("Brand do not exist");
            }

            var car = new Car()
            {
                ModelName = dto.ModelName,
                Price = dto.Price,
                Brand = brand,
            };

            try
            {
                _carService.AddCar(car);
            }
            catch
            {
                return BadRequest("Impossible to add the car");
            }

            CarDto dtoToReturn = new()
            {
                Brand = car.Brand.Name,
                Id = car.Id,
                ModelName = car.ModelName,
                Price = car.Price,
                SoldTime = car.SoldTime,
            };

            return Ok(dtoToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarById([FromRoute] int id, [FromBody] UpdateCarDto newCarData)
        {
            var car = _carService.GetById(id);

            if (car is null)
            {
                return BadRequest("Can not update a car which does not exist");
            }

            CarBrand brand = _brandService.GetBrandByName(newCarData.BrandName);

            if (brand is null)
            {
                return BadRequest("Brand do not exist");
            }

            car.Price = newCarData.Price;
            car.ModelName = newCarData.ModelName;
            car.Brand = brand;

            try
            {
                _carService.UpdateCar(car);
            }
            catch
            {
                return BadRequest("Impossible to update the car");
            }

            return Ok();
        }

        [HttpPost("{id}/sell")]
        public IActionResult SellCar([FromRoute] int id, [FromBody] int sellerId)
        {
            var car = _carService.GetById(id);

            if (car is null)
            {
                return BadRequest("Can not sell a car which does not exist");
            }

            Seller seller = _sellerService.GetById(sellerId);

            if (seller is null)
            {
                return BadRequest("Can not find a seller with this id");
            }

            car.SoldTime = DateTime.Now;

            Operation operation = new Operation()
            {
                Seller = seller,
                Car = car,
                Description = "Sold",
                TransactionTime = DateTime.Now,
            };

            seller.Comission += car.Price * Commission.SellerCommissionPercent / 100;

            _sellerService.UpdateSeller(seller);
            _carService.UpdateCar(car);
            _operationService.AddOperation(operation);

            return Ok();
        }
    }
}
