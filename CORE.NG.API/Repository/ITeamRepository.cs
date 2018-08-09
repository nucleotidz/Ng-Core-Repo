using CORE.NG.API.DBModel;
using CORE.NG.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.NG.API.Repository
{
    public interface ITeamRepository: IBaseRepository
    {
        void Save();
        List<user> Get();
    }
}
