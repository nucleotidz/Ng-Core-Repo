using CORE.NG.DATA.DBModel;
using CORE.NG.MODELS;
using System.Collections.Generic;

namespace CORE.NG.DATA.Repository
{
    public interface ITeamRepository
    {
        void Save(TeamDTO team);
        List<TeamDTO> Get();
    }
}
