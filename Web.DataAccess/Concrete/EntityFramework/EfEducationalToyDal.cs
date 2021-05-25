using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.DataAccess.EntityFramework;
using Web.DataAccess.Abstract;
using Web.Entities.Concrete;

namespace Web.DataAccess.Concrete.EntityFramework
{
    public class EfEducationalToyDal : EfEntityRepositoryBase<EducationalToy, OyuncakSatisContext>, IEducationalToyDal
    {

    }
}
