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
   public class EducationalToyManager : IEducationalToyService
    {
        IEducationalToyDal _educationalToyDal;

        public EducationalToyManager(IEducationalToyDal educationalToyDal)
        {
            _educationalToyDal = educationalToyDal;
        }

        public IResult Add(EducationalToy educationalToy)
        {
            BusinessRules.Run(CheckIfEducationalToyNameExists(educationalToy.Name));

            _educationalToyDal.Add(educationalToy);
            return new SuccessResult(Messages.EducationalToyAdded);
        }

        public IResult Delete(EducationalToy educationalToy)
        {
            _educationalToyDal.Delete(educationalToy);
            return new SuccessResult(Messages.EducationalToyDeleted);
        }

        public IDataResult<List<EducationalToy>> GetAll()
        {
            return new SuccessDataResult<List<EducationalToy>>(_educationalToyDal.GetAll());
        }

        public IDataResult<List<EducationalToy>> GetAllByEducationalId(int educationalId)
        {
            return new SuccessDataResult<List<EducationalToy>>(_educationalToyDal.GetAll(e => e.EducationalId == educationalId));
        }

        public IDataResult<EducationalToy> GetById(int educationalToyId)
        {
            return new SuccessDataResult<EducationalToy>(_educationalToyDal.Get(e => e.Id == educationalToyId));
        }

        public IResult Update(EducationalToy educationalToy)
        {
            _educationalToyDal.Update(educationalToy);
            return new SuccessResult(Messages.EducationalToyUpdated);
        }
        private IResult CheckIfEducationalToyNameExists(string educationalToyName)
        {
            var result = _educationalToyDal.GetAll(e => e.Name == educationalToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.EducationalToyNameAlreadyExists);
        }
    }
}
