using Desafio_Core.Models;

namespace Desafio_Infrastructure.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> GetAll();
        T GetById(int id);
        void Create(T entidade);
        void Update(T entidade);
        void Delete(int id);
    }    
}
