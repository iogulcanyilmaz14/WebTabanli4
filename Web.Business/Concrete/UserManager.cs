using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Abstract;
using Web.Business.Constants;
using Web.Core.Entities.Concrete;
using Web.Core.Utilities.Business;
using Web.Core.Utilities.Results;
using Web.DataAccess.Abstract;

namespace Web.Business.Concrete
{
   public class UserManager : IUserService
    {
        private IUserDal _userDal;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            BusinessRules.Run(CheckIfUserNameExists(user.FirstName));

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<User>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.userId == userId));
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        private IResult CheckIfUserNameExists(string userName)
        {
            var result = _userDal.GetAll(u => u.FirstName == userName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserNameAlreadyExists);
        }
    }
}
