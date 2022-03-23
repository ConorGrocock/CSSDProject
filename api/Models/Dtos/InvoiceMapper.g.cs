using System.Collections.Generic;
using api.Models.Dtos;
using api.Models.Entities;

namespace api.Models.Dtos
{
    public static partial class InvoiceMapper
    {
        public static ViewInvoiceDto AdaptToViewDto(this Invoice p1)
        {
            return p1 == null ? null : new ViewInvoiceDto()
            {
                PaymentReference = p1.PaymentReference,
                IssuedAt = p1.IssuedAt,
                Amount = p1.Amount,
                Account = p1.Account == null ? null : new BasicAccountDto()
                {
                    Name = p1.Account.Name,
                    Email = p1.Account.Email,
                    Id = p1.Account.Id
                },
                Bills = funcMain1(p1.Bills),
                Id = p1.Id
            };
        }
        public static ViewInvoiceDto AdaptTo(this Invoice p3, ViewInvoiceDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            ViewInvoiceDto result = p4 ?? new ViewInvoiceDto();
            
            result.PaymentReference = p3.PaymentReference;
            result.IssuedAt = p3.IssuedAt;
            result.Amount = p3.Amount;
            result.Account = funcMain2(p3.Account, result.Account);
            result.Bills = funcMain3(p3.Bills, result.Bills);
            result.Id = p3.Id;
            return result;
            
        }
        
        private static ViewBillDto[] funcMain1(List<Bill> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            ViewBillDto[] result = new ViewBillDto[p2.Count];
            
            int v = 0;
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                Bill item = p2[i];
                result[v++] = item == null ? null : new ViewBillDto()
                {
                    Amount = item.Amount,
                    IssuedAt = item.IssuedAt,
                    Id = item.Id
                };
                i++;
            }
            return result;
            
        }
        
        private static BasicAccountDto funcMain2(Account p5, BasicAccountDto p6)
        {
            if (p5 == null)
            {
                return null;
            }
            BasicAccountDto result = p6 ?? new BasicAccountDto();
            
            result.Name = p5.Name;
            result.Email = p5.Email;
            result.Id = p5.Id;
            return result;
            
        }
        
        private static ViewBillDto[] funcMain3(List<Bill> p7, ViewBillDto[] p8)
        {
            if (p7 == null)
            {
                return null;
            }
            ViewBillDto[] result = new ViewBillDto[p7.Count];
            
            int v = 0;
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                Bill item = p7[i];
                result[v++] = item == null ? null : new ViewBillDto()
                {
                    Amount = item.Amount,
                    IssuedAt = item.IssuedAt,
                    Id = item.Id
                };
                i++;
            }
            return result;
            
        }
    }
}