using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Utilities.Results;
using Web.Entities.Concrete;

namespace Web.Business.Abstract
{
   public interface IScienceToyService
    {
        IResult Add(ScienceToy scienceToy);
        IResult Delete(ScienceToy scienceToy);
        IResult Update(ScienceToy scienceToy);
        IDataResult<ScienceToy> GetById(int scienceToyId);
        IDataResult<List<ScienceToy>> GetAll();
        IDataResult<List<ScienceToy>> GetAllByScienceId(int scienceId);
    }
}
