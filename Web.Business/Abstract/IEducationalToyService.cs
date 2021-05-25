using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Utilities.Results;
using Web.Entities.Concrete;

namespace Web.Business.Abstract
{
    public interface IEducationalToyService
    {
        IResult Add(EducationalToy educationalToy);
        IResult Delete(EducationalToy educationalToy);
        IResult Update(EducationalToy educationalToy);
        IDataResult<EducationalToy> GetById(int educationalToyId);
        IDataResult<List<EducationalToy>> GetAll();
        IDataResult<List<EducationalToy>> GetAllByEducationalId(int educationalId);

    }
}
