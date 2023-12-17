using Core.Utilities.Abstract;
using Core.Utilities;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        IResult Add(Question question);
        IResult Delete(Question question);
        IResult Update(Question question);
       
    }
}
