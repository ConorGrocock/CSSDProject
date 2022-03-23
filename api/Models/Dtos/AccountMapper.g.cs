using api.Models.Dtos;
using api.Models.Entities;

namespace api.Models.Dtos
{
    public static partial class AccountMapper
    {
        public static Account AdaptToAccount(this CreateAccountDto p1)
        {
            return p1 == null ? null : new Account()
            {
                Name = p1.Name,
                Email = p1.Email,
                ImmediatePayment = p1.ImmediatePayment,
                PostalAddress = p1.PostalAddress == null ? null : new Address()
                {
                    Line1 = p1.PostalAddress.Line1,
                    Line2 = p1.PostalAddress.Line2,
                    Line3 = p1.PostalAddress.Line3,
                    City = p1.PostalAddress.City,
                    State = p1.PostalAddress.State,
                    Country = p1.PostalAddress.Country,
                    Postcode = p1.PostalAddress.Postcode
                }
            };
        }
        public static Account AdaptTo(this CreateAccountDto p2, Account p3)
        {
            if (p2 == null)
            {
                return null;
            }
            Account result = p3 ?? new Account();
            
            result.Name = p2.Name;
            result.Email = p2.Email;
            result.ImmediatePayment = p2.ImmediatePayment;
            result.PostalAddress = funcMain1(p2.PostalAddress, result.PostalAddress);
            return result;
            
        }
        public static BasicAccountDto AdaptToBasicDto(this Account p6)
        {
            return p6 == null ? null : new BasicAccountDto()
            {
                Name = p6.Name,
                Email = p6.Email,
                Id = p6.Id
            };
        }
        public static BasicAccountDto AdaptTo(this Account p7, BasicAccountDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            BasicAccountDto result = p8 ?? new BasicAccountDto();
            
            result.Name = p7.Name;
            result.Email = p7.Email;
            result.Id = p7.Id;
            return result;
            
        }
        
        private static Address funcMain1(CreateAddressDto p4, Address p5)
        {
            if (p4 == null)
            {
                return null;
            }
            Address result = p5 ?? new Address();
            
            result.Line1 = p4.Line1;
            result.Line2 = p4.Line2;
            result.Line3 = p4.Line3;
            result.City = p4.City;
            result.State = p4.State;
            result.Country = p4.Country;
            result.Postcode = p4.Postcode;
            return result;
            
        }
    }
}