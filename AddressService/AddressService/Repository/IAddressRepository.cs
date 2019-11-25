using System.Collections.Generic;

namespace AddressService.Repository
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        IEnumerable<string> GetAggregateAddresses();
        void InsertAddress(Address address);
        void DeleteAddressById(int id);
        void Save();
    }
}
