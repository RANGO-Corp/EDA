using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Alere.Models;
using Alere.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public IList<Requisition> FindAllByCondition(Expression<Func<Requisition, bool>> condition)
        {
            return _context
                        .Requisitions
                        .Include(e => e.Receiver)
                        .Include(e => e.Food)
                        .Where(condition)
                        .OrderByDescending(e => e.Date)
                    .ToList()
                    ;
        }

        public Requisition FindByCondition(Expression<Func<Requisition, bool>> condition)
        {
            return _context
                        .Requisitions
                        .Include(e => e.Receiver)
                        .Include(e => e.Food)
                        .Where(condition)
                    .FirstOrDefault()
                    ;
        }

        public Requisition FindById(long id)
        {
            return _context
                        .Requisitions
                        .Where(e => e.RequisitionId == id)
                        .FirstOrDefault()
                    ;
        }

        public void SetStatusByCondition(Status status, Expression<Func<Requisition, bool>> condition)
        {
            Requisition requisition = FindByCondition(condition);
            requisition.Status = status;
            Update(requisition);
        }

        public void Store(Requisition entity)
        {
            _context.Requisitions.Add(entity);
        }

        public void Update(Requisition entity)
        {
            _context.Requisitions.Update(entity);
            _context.Entry(entity).Property(p => p.Date).IsModified = false;
        }
    }
}