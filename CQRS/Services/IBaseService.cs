namespace CQRS.Services
{
    using CQRS.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseService<TEntity, TDto>
    {
        string UserId { get; }

        string UserName { get; }

        string Email { get; }

        PageResultDto<TDto> Search(IQuery<IList<TEntity>> query, int take = 10, int skip = 0);

        TDto GetBy(IQuery<TEntity> query);

        Task<TDto> CreateAsync(TDto model);

        Task<TDto> UpdateAsync(TDto model);

        Task DeleteAsync(params object[] keyValues);
    }
}
