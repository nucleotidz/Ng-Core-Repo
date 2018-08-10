using CORE.NG.DATA.DBModel;
using CORE.NG.UOW;
using System.Collections.Generic;

namespace CORE.NG.DATA.Repository
{
    public interface ITeamRepository: IBaseRepository
    {
        void Save();
        List<Team> Get();
    }
}
