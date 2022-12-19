namespace Mundial.BAL.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericShow<C>
        where C : class
    {
        Task<C> GetById(int id);
        Task<IEnumerable<C>> GetAll();
    }
}
