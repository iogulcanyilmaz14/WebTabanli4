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
    public class ScienceToyManager : IScienceToyService
    {
        IScienceToyDal _scienceToyDal;
        public ScienceToyManager(IScienceToyDal scienceToyDal)
        {
            _scienceToyDal = scienceToyDal;
        }
        public IResult Add(ScienceToy scienceToy)
        {
            BusinessRules.Run(CheckIfScienceToyNameExists(scienceToy.Name));

            _scienceToyDal.Add(scienceToy);
            return new SuccessResult(Messages.ScienceToyAdded);
        }

        public IResult Delete(ScienceToy scienceToy)
        {
            _scienceToyDal.Delete(scienceToy);
            return new SuccessResult(Messages.ScienceToyDeleted);
        }

        public IDataResult<List<ScienceToy>> GetAll()
        {
            return new SuccessDataResult<List<ScienceToy>>(_scienceToyDal.GetAll());
        }

        public IDataResult<List<ScienceToy>> GetAllByScienceId(int scienceId)
        {
            return new SuccessDataResult<List<ScienceToy>>(_scienceToyDal.GetAll(s => s.ScienceId == scienceId));
        }

        public IDataResult<ScienceToy> GetById(int scienceToyId)
        {
            return new SuccessDataResult<ScienceToy>(_scienceToyDal.Get(s => s.Id == scienceToyId));
        }

        public IResult Update(ScienceToy scienceToy)
        {
            _scienceToyDal.Update(scienceToy);
            return new SuccessResult(Messages.ScienceToyUpdated);
        }
        private IResult CheckIfScienceToyNameExists(string scienceToyName)
        {
            var result = _scienceToyDal.GetAll(s => s.Name == scienceToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ScienceToyNameAlreadyExists);
        }
    }
}
