namespace CQRS.Services
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using CQRS.UnitOfWork;
    using CQRS.Repository;
    using CQRS.Commons;
    using CQRS.Dto;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain;

    public abstract class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IRepository<TEntity> _reponsitory;

        protected readonly IDatabase _database;

        public string UserId
        {
            get
            {
                return _unitOfWork.UserId;
            }
        }

        public string UserName
        {
            get
            {
                return _unitOfWork.UserName;
            }
        }

        public string Email
        {
            get
            {
                return _unitOfWork.Email;
            }
        }

        public BaseService(IUnitOfWork unitOfWork, IDatabase database)
        {
            _unitOfWork = unitOfWork;

            _database = database;

            _reponsitory = unitOfWork.GetPropValue<IRepository<TEntity>>(typeof(TEntity).Name + "Repository");
        }

        public virtual async Task<TDto> CreateAsync(TDto model)
        {
            var entity = DtoToEntity(model);

            _reponsitory.Add(entity);

            await _unitOfWork.CommitAsync();

            return EntityToDto(entity);
        }

        public virtual async Task<TDto> UpdateAsync(TDto model)
        {
            var entity = DtoToEntity(model);

            _reponsitory.Update(entity);

            await _unitOfWork.CommitAsync();

            return EntityToDto(entity);

        }

        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            var entity = await _reponsitory.FindByAsync(keyValues);

            if (entity == null) throw new Exception("Not found entity object with id: " + keyValues);

            _reponsitory.Delete(entity);

            await _unitOfWork.CommitAsync();
        }

        public virtual PageResultDto<TDto> Search(IQuery<IList<TEntity>> query, int take = 10, int skip = 0)
        {
            var data = FindAll(query);

            var result = data.Skip(skip).Take(take);

            return new PageResultDto<TDto>(data.Count, GetTotalPage(data.Count, take), EntityToDto(data));
        }

        public virtual TDto GetBy(IQuery<TEntity> query)
        {
            var result = _database.Query(query);

            return EntityToDto(result);
        }

        protected IList<TEntity> FindAll(IQuery<IList<TEntity>> query)
        {
            return _database.Query(query);
        }

        protected TDto EntityToDto(TEntity entity)
        {
            return Mapper.Map<TDto>(entity);
        }

        protected TEntity DtoToEntity(TDto dto)
        {
            return Mapper.Map<TEntity>(dto);
        }

        protected TEntity DtoToEntity(TDto dto, TEntity entity)
        {
            return Mapper.Map(dto, entity);
        }

        protected IEnumerable<TDto> EntityToDto(IEnumerable<TEntity> entities)
        {
            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        protected IEnumerable<TEntity> DtoToEntity(IEnumerable<TDto> dto)
        {
            return Mapper.Map<IEnumerable<TEntity>>(dto);
        }

        protected int GetTotalPage(int totalRecord, int take)
        {
            if (take > 0)
            {
                return (int)Math.Ceiling((double)((double)totalRecord / (double)take));
            }
            throw new Exception("The take parameter require greater than zero.");
        }
    }
}
