using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Abstract;
using Web.Business.Constants;
using Web.Core.Utilities.Business;
using Web.Core.Utilities.Results;
using Web.DataAccess.Abstract;
using Web.Entities.Concrete;

namespace Web.Business.Concrete
{
    public class PlushToyManager : IPlushToyService
    {
        IPlushToyDal _plushToyDal;

        public PlushToyManager(IPlushToyDal plushToyDal)
        {
            _plushToyDal = plushToyDal;
        }

        public IResult Add(PlushToy plushToy)
        {
            BusinessRules.Run(CheckIfPlushToyNameExists(plushToy.Name));

            _plushToyDal.Add(plushToy);
            return new SuccessResult(Messages.PlushToyAdded);
        }

        public IResult Delete(PlushToy plushToy)
        {
            _plushToyDal.Delete(plushToy);
            return new SuccessResult(Messages.PlushToyDeleted);
        }

        public IDataResult<List<PlushToy>> GetAll()
        {
            return new SuccessDataResult<List<PlushToy>>(_plushToyDal.GetAll());
        }

        public IDataResult<List<PlushToy>> GetAllByPlushId(int plushId)
        {
            return new SuccessDataResult<List<PlushToy>>(_plushToyDal.GetAll(p => p.PlushId == plushId));
        }

        public IDataResult<PlushToy> GetById(int PlushToyId)
        {
            return new SuccessDataResult<PlushToy>(_plushToyDal.Get(p => p.Id == PlushToyId));
        }

        public IResult Update(PlushToy plushToy)
        {
            _plushToyDal.Update(plushToy);
            return new SuccessResult(Messages.PlushToyUpdated);
        }
        private IResult CheckIfPlushToyNameExists(string plushToyName)
        {
            var result = _plushToyDal.GetAll(p => p.Name == plushToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PlushToyNameAlreadyExists);
        }
    }
}
