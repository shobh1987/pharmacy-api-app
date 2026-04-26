using PharmacyApi.Models;

namespace PharmacyApi.Data.Interfaces
{
    public interface IBaseData<T> where T : class
    {
        Task<T> GetByIdAsync(long id); 

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(long id, T entity);

        Task<bool> DeleteAsync(long id);
    }
}
