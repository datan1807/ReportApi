using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;

namespace Api.Services.IService
{
    public interface IMarkService :IGenericService<MarkDto>
    {
        Task<PagingData<ExtendedMarkDto>> Search(MarkParameter param);
    }
}
