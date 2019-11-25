using AddressService.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Transactions;

namespace AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var addresses = _addressRepository.GetAddresses().Select(x => new { x.AggregateCity, x.City, x.Country, x.FirstName, x.LastName, x.StreetAddress});
            var groupedAddresses = addresses.GroupBy(a => a.AggregateCity)
                .Select(g => g.ToArray())
                .ToArray();
            return new OkObjectResult(groupedAddresses);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            address.AggregateCity = AddressUtils.GetAggregateCity(address, _addressRepository.GetAggregateAddresses());

            using (var scope = new TransactionScope())
            {
                _addressRepository.InsertAddress(address);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = address.ID }, address);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _addressRepository.DeleteAddressById(id);
            return new OkResult();
        }
    }
}
