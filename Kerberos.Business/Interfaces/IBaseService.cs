using Kerberos.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Business.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
    }
}
