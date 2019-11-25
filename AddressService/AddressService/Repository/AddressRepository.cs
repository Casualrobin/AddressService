using AddressService.DBContexts;
using System.Collections.Generic;
using System.Linq;

namespace AddressService.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _dbContext;
        public AddressRepository(AddressContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteAddressById(int id)
        {
            var address = _dbContext.Addresses.Find(id);
            _dbContext.Addresses.Remove(address);
            Save();
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _dbContext.Addresses.ToList();
        }

        public IEnumerable<string> GetAggregateAddresses()
        {
            return _dbContext.Addresses.Select(a => a.AggregateCity).Distinct().ToList();
        }

        public void InsertAddress(Address address)
        {
            _dbContext.Add(address);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
