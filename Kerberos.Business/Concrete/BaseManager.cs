using Kerberos.Business.Interfaces;
using Kerberos.DataAccess.Interfaces;
using Kerberos.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Business.Concrete
{
    public class BaseManager<TEntity> : IBaseService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IBaseRepository<TEntity> _baseRepo;
        public BaseManager(IBaseRepository<TEntity> baseRepo)
        {
            _baseRepo = baseRepo;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _baseRepo.AddAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _baseRepo.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _baseRepo.GetByIdAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
             await _baseRepo.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _baseRepo.UpdateAsync(entity);
        }
    }
}
