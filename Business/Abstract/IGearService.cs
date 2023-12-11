using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGearService
    {
        IResult Add(Gear gear);

        IDataResult<List<Gear>> GetAll();

        IDataResult<Gear> GetById(int gearId);
    }
}
