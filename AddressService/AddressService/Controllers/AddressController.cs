using AddressService.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IActionResult PostMultipleAddresses([FromBody] IEnumerable<Address> addresses)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var address in addresses)
                {
                    address.AggregateCity = AddressUtils.GetAggregateCity(address, _addressRepository.GetAggregateAddresses());
                    _addressRepository.InsertAddress(address);  
                }
                scope.Complete();

                return CreatedAtAction(nameof(Get), new { id = addresses.Select(a => a.ID) });
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
