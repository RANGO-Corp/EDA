using System.Collections.Generic;
using System.Linq;
using Alere.Models;
using Alere.Persistence;

namespace Alere.Repositories.Impl
{
    public class RequisitionRepository : IRequisitionRepository
    {
        private FactoryContext _context;

        public RequisitionRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Requisition> FindAll()
        {
            return _context.Requisitions.ToList();
        }

        public Requisition FindById(long id)
        {
            return _context
                        .Requisitions
                        .Where(e => e.RequisitionId == id)
                        .FirstOrDefault()
                    ;
        }

        public void Store(Requisition entity)
        {
            _context.Requisitions.Add(entity);
        }

        public void Update(Requisition entity)
        {
            _context.Requisitions.Update(entity);
        }
    }
}