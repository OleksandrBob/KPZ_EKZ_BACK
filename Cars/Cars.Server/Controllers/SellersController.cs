using Cars.Core.Services.Interfaces;
using Cars.DAL.Models;
using Cars.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetSellerById(int id)
        {
            var seller = _sellerService.GetById(id);

            if (seller is null)
            {
                return BadRequest("Seller do not exist");
            }

            SellerDto dtoToReturn = new()
            {
                Id = seller.Id,
                Comission = seller.Comission,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
            };

            return Ok(dtoToReturn);
        }

        [HttpPost]
        public IActionResult AddSeller(UpdateSellerDto dto)
        {
            var seller = new Seller()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password
            };

            try
            {
                _sellerService.AddSeller(seller);
            }
            catch
            {
                return BadRequest("Impossible to add the seller");
            }

            SellerDto dtoToReturn = new()
            {
                Comission = seller.Comission,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
            };

            return Ok(dtoToReturn);
        }
    }
}
