﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.DataAccess;
using Web.Core.Entities.Concrete;

namespace Web.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
    }
}
