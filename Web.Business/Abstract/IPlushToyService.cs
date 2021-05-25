using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Utilities.Results;
using Web.Entities.Concrete;

namespace Web.Business.Abstract
{
    public interface IPlushToyService
    {
        IResult Add(PlushToy plushToy);
        IResult Delete(PlushToy plushToy);
        IResult Update(PlushToy plushToy);
        IDataResult<PlushToy> GetById(int PlushToyId);
        IDataResult<List<PlushToy>> GetAll();
        IDataResult<List<PlushToy>> GetAllByPlushId(int plushId);

    }
}
