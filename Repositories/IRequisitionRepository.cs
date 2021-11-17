using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Alere.Models;

namespace Alere.Repositories
{
    public interface IRequisitionRepository : ICrudRepository<Requisition, long>
    {
        IList<Requisition> FindAllByCondition(Expression<Func<Requisition, bool>> condition);
    }
}