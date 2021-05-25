using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Utilities.Results;
using Web.Entities.Concrete;

namespace Web.Business.Abstract
{
   public interface IPuzzleToyService
    {
        IResult Add(PuzzleToy puzzleToy);
        IResult Delete(PuzzleToy puzzleToy);
        IResult Update(PuzzleToy puzzleToy);
        IDataResult<PuzzleToy> GetById(int puzzleToyId);
        IDataResult<List<PuzzleToy>> GetAll();
        IDataResult<List<PuzzleToy>> GetAllByPuzzleId(int puzzleId);
    }
}
