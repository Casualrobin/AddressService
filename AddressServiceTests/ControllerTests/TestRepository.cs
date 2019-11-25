using AddressService;
using AddressService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressServiceTests.RepositoryTests
{
    public class TestRepository : IAddressRepository
    {
        public TestRepository()
        {
            data = new List<Address>();
        }
        public List<Address> data { get; set; }

        public void DeleteAddressById(int id)
        {
            data.Remove(data.Where(x => x.ID == id).FirstOrDefault());
        }

        public Address GetAddressById(int id)
        {
            return data.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return data;
        }

        public IEnumerable<string> GetAggregateAddresses()
        {
            return data.Select(a => a.AggregateCity).Distinct().ToList();
        }

        public void InsertAddress(Address address)
        {
            data.Add(address);
        }

        public void Save()
        {
            
        }

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
