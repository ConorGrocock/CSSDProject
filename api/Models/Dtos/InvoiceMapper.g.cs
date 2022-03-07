using api.Models.Dtos;
using api.Models.Entities;
using Mapster;

namespace api.Models.Dtos
{
    public static partial class InvoiceMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static InvoiceDto AdaptToDto(this Invoice p1)
        {
            return p1 == null ? null : new InvoiceDto()
            {
                Amount = p1.Amount,
                PaymentReference = p1.PaymentReference,
                IssuedAt = p1.IssuedAt,
                Bills = funcMain1(p1.Bills)
            };
        }
        public static InvoiceDto AdaptTo(this Invoice p3, InvoiceDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            InvoiceDto result = p4 ?? new InvoiceDto();
            
            result.Amount = p3.Amount;
            result.PaymentReference = p3.PaymentReference;
            result.IssuedAt = p3.IssuedAt;
            result.Bills = funcMain2(p3.Bills, result.Bills);
            return result;
            
        }
        
        private static Bill[] funcMain1(Bill[] p2)
        {
            if (p2 == null)
            {
                return null;
            }
            Bill[] result = new Bill[p2.Length];
            
            int v = 0;
            
            int i = 0;
            int len = p2.Length;
            
            while (i < len)
            {
                Bill item = p2[i];
                result[v++] = item == null ? null : new Bill()
                {
                    Amount = item.Amount,
                    IssuedAt = item.IssuedAt,
                    InvoiceId = item.InvoiceId,
                    Invoice = item.Invoice == null ? null : new Invoice()
                    {
                        Amount = item.Invoice.Amount,
                        PaymentReference = item.Invoice.PaymentReference,
                        IssuedAt = item.Invoice.IssuedAt,
                        AccountId = item.Invoice.AccountId,
                        Account = item.Invoice.Account == null ? null : new Account()
                        {
                            Name = item.Invoice.Account.Name,
                            Email = item.Invoice.Account.Email,
                            ImmediatePayment = item.Invoice.Account.ImmediatePayment,
                            PostalAddressId = item.Invoice.Account.PostalAddressId,
                            PostalAddress = item.Invoice.Account.PostalAddress == null ? null : new Address()
                            {
                                Line1 = item.Invoice.Account.PostalAddress.Line1,
                                Line2 = item.Invoice.Account.PostalAddress.Line2,
                                Line3 = item.Invoice.Account.PostalAddress.Line3,
                                City = item.Invoice.Account.PostalAddress.City,
                                State = item.Invoice.Account.PostalAddress.State,
                                Country = item.Invoice.Account.PostalAddress.Country,
                                Postcode = item.Invoice.Account.PostalAddress.Postcode,
                                Id = item.Invoice.Account.PostalAddress.Id
                            },
                            Id = item.Invoice.Account.Id
                        },
                        PostalAddressId = item.Invoice.PostalAddressId,
                        PostalAddress = item.Invoice.PostalAddress == null ? null : new Address()
                        {
                            Line1 = item.Invoice.PostalAddress.Line1,
                            Line2 = item.Invoice.PostalAddress.Line2,
                            Line3 = item.Invoice.PostalAddress.Line3,
                            City = item.Invoice.PostalAddress.City,
                            State = item.Invoice.PostalAddress.State,
                            Country = item.Invoice.PostalAddress.Country,
                            Postcode = item.Invoice.PostalAddress.Postcode,
                            Id = item.Invoice.PostalAddress.Id
                        },
                        Bills = TypeAdapterConfig1.GetMapFunction<Bill[], Bill[]>().Invoke(item.Invoice.Bills),
                        Id = item.Invoice.Id
                    },
                    JourneyId = item.JourneyId,
                    Journey = item.Journey == null ? null : new Journey()
                    {
                        Distance = item.Journey.Distance,
                        Id = item.Journey.Id
                    },
                    Id = item.Id
                };
                i++;
            }
            return result;
            
        }
        
        private static Bill[] funcMain2(Bill[] p5, Bill[] p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Bill[] result = new Bill[p5.Length];
            
            int v = 0;
            
            int i = 0;
            int len = p5.Length;
            
            while (i < len)
            {
                Bill item = p5[i];
                result[v++] = item == null ? null : new Bill()
                {
                    Amount = item.Amount,
                    IssuedAt = item.IssuedAt,
                    InvoiceId = item.InvoiceId,
                    Invoice = item.Invoice == null ? null : new Invoice()
                    {
                        Amount = item.Invoice.Amount,
                        PaymentReference = item.Invoice.PaymentReference,
                        IssuedAt = item.Invoice.IssuedAt,
                        AccountId = item.Invoice.AccountId,
                        Account = item.Invoice.Account == null ? null : new Account()
                        {
                            Name = item.Invoice.Account.Name,
                            Email = item.Invoice.Account.Email,
                            ImmediatePayment = item.Invoice.Account.ImmediatePayment,
                            PostalAddressId = item.Invoice.Account.PostalAddressId,
                            PostalAddress = item.Invoice.Account.PostalAddress == null ? null : new Address()
                            {
                                Line1 = item.Invoice.Account.PostalAddress.Line1,
                                Line2 = item.Invoice.Account.PostalAddress.Line2,
                                Line3 = item.Invoice.Account.PostalAddress.Line3,
                                City = item.Invoice.Account.PostalAddress.City,
                                State = item.Invoice.Account.PostalAddress.State,
                                Country = item.Invoice.Account.PostalAddress.Country,
                                Postcode = item.Invoice.Account.PostalAddress.Postcode,
                                Id = item.Invoice.Account.PostalAddress.Id
                            },
                            Id = item.Invoice.Account.Id
                        },
                        PostalAddressId = item.Invoice.PostalAddressId,
                        PostalAddress = item.Invoice.PostalAddress == null ? null : new Address()
                        {
                            Line1 = item.Invoice.PostalAddress.Line1,
                            Line2 = item.Invoice.PostalAddress.Line2,
                            Line3 = item.Invoice.PostalAddress.Line3,
                            City = item.Invoice.PostalAddress.City,
                            State = item.Invoice.PostalAddress.State,
                            Country = item.Invoice.PostalAddress.Country,
                            Postcode = item.Invoice.PostalAddress.Postcode,
                            Id = item.Invoice.PostalAddress.Id
                        },
                        Bills = TypeAdapterConfig1.GetMapFunction<Bill[], Bill[]>().Invoke(item.Invoice.Bills),
                        Id = item.Invoice.Id
                    },
                    JourneyId = item.JourneyId,
                    Journey = item.Journey == null ? null : new Journey()
                    {
                        Distance = item.Journey.Distance,
                        Id = item.Journey.Id
                    },
                    Id = item.Id
                };
                i++;
            }
            return result;
            
        }
    }
}