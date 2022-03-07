using api.Models.Dtos;
using api.Models.Entities;

namespace api.Models.Dtos
{
    public static partial class AddressMapper
    {
        public static Address AdaptToAddress(this CreateAddressDto p1)
        {
            return p1 == null ? null : new Address()
            {
                Line1 = p1.Line1,
                Line2 = p1.Line2,
                Line3 = p1.Line3,
                City = p1.City,
                State = p1.State,
                Country = p1.Country,
                Postcode = p1.Postcode
            };
        }
        public static Address AdaptTo(this CreateAddressDto p2, Address p3)
        {
            if (p2 == null)
            {
                return null;
            }
            Address result = p3 ?? new Address();
            
            result.Line1 = p2.Line1;
            result.Line2 = p2.Line2;
            result.Line3 = p2.Line3;
            result.City = p2.City;
            result.State = p2.State;
            result.Country = p2.Country;
            result.Postcode = p2.Postcode;
            return result;
            
        }
    }
}