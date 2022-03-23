using api.Models.Dtos;
using api.Models.Entities;
using Mapster;

namespace api.Services.Common.Mapping;

public class NorTollMappingConfiguration : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptFrom(nameof(CreateAccountDto))
            .ForType<Account>();

        config.AdaptTo(nameof(BasicAccountDto))
            .ForType<Account>();

        config.AdaptTo(nameof(ViewBillDto))
            .ForType<Bill>();

        config.AdaptTo(nameof(ViewInvoiceDto))
            .ForType<Invoice>();

        config.GenerateMapper("[name]Mapper")
            .ForType<Account>()
            .ForType<Invoice>();
    }
}