using api.Models;
using api.Models.Dtos;
using api.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Common.Interfaces;
public interface IInvoiceService
{
    Task<InvoiceDto> GetInvoices();
}