﻿using System;
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
   public class PuzzleToyManager : IPuzzleToyService
    {
        IPuzzleToyDal _puzzleToyDal;

        public PuzzleToyManager(IPuzzleToyDal puzzleToyDal)
        {
            _puzzleToyDal = puzzleToyDal;
        }

        public IResult Add(PuzzleToy puzzleToy)
        {
            BusinessRules.Run(CheckIfPuzzleToyNameExists(puzzleToy.Name));

            _puzzleToyDal.Add(puzzleToy);
            return new SuccessResult(Messages.PuzzleToyAdded);
        }

        public IResult Delete(PuzzleToy puzzleToy)
        {
            _puzzleToyDal.Delete(puzzleToy);
            return new SuccessResult(Messages.PuzzleToyDeleted);
        }

        public IDataResult<List<PuzzleToy>> GetAll()
        {
            return new SuccessDataResult<List<PuzzleToy>>(_puzzleToyDal.GetAll());
        }

        public IDataResult<List<PuzzleToy>> GetAllByPuzzleId(int puzzleId)
        {
            return new SuccessDataResult<List<PuzzleToy>>(_puzzleToyDal.GetAll(pu => pu.PuzzleId == puzzleId));
        }

        public IDataResult<PuzzleToy> GetById(int puzzleToyId)
        {
            return new SuccessDataResult<PuzzleToy>(_puzzleToyDal.Get(pu => pu.Id == puzzleToyId));
        }

        public IResult Update(PuzzleToy puzzleToy)
        {
            _puzzleToyDal.Update(puzzleToy);
            return new SuccessResult(Messages.PuzzleToyUpdated);
        }
        private IResult CheckIfPuzzleToyNameExists(string puzzleToyName)
        {
            var result = _puzzleToyDal.GetAll(pu => pu.Name == puzzleToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PuzzleToyNameAlreadyExists);
        }
    }
}
