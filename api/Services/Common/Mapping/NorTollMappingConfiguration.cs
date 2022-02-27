using api.Models.Dtos;
using api.Models.Entities;
using Mapster;

namespace api.Services.Common.Mapping;

public class NorTollMappingConfiguration : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config
           .AdaptFrom(CreateDto)
           .ForType<Address>(x => x.Ignore(x => x.Id));

        config
            .AdaptFrom(CreateDto)
            .ForType<Account>(x => x
                .Ignore(x => x.Id)
                .Ignore(x => x.PostalAddressId)
                .Map(x => x.PostalAddress, typeof(CreateAddressDto)));
    }
    private string CreateDto { get; } = "Create[name]Dto";
}