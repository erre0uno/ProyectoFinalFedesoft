namespace Mundial.BAL.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    public interface IGeneric<C> where C : class
    {
        Task<C> CreateAsync(C c);
        Task<HttpStatusCode> DeleteAsync(int id);
        Task<C> GetById(int id);
        Task<IEnumerable<C>> GetAll();
        Task<HttpStatusCode> UpdateAsync(C c);
    }
}
