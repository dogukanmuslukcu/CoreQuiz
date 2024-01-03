using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entity.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExamDal : IEntityRepository<Exam>
    {
        Exam GetExamDetails(int Id);
    }
}
