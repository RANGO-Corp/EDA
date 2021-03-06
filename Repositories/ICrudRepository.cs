using System.Collections.Generic;

namespace Alere.Repositories
{
    public interface ICrudRepository<E, K>
    {
        void Store(E entity);
        void Update(E entity);
        int Commit();
        E FindById(K id);
        IList<E> FindAll();
    }
}