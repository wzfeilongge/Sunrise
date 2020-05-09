using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SunriseEnterpriseIRepository.IBaseRepositorys
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T model);
        Task<int> AddRangeModels(List<T> model);
        Task<List<T>> Query(Expression<Func<T, bool>> whereLambda);
        Task<T> GetModelAsync(Expression<Func<T, bool>> whereLambda);
        Task<int> Count(Expression<Func<T, bool>> whereLambda);
        Task<List<T>> GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true);
        Task<int> DelBy(Expression<Func<T, bool>> delWhere);
        Task<int> AddModel(T model);
        Task<int> Modify(T model);
        Task<int> Modify(T model, params string[] propertyNames);
        Task<int> UpdateContext(T Model);
        IQueryable<T> GetAll(Expression<Func<T, bool>> whereLambda);
    }
}
