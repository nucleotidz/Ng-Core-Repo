using CORE.NG.DATA.DBModel;
using CORE.NG.MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace NG.CORE.BUSINESS
{
    public interface ITeamBL
    {
        void Save(TeamDTO team);
        List<TeamDTO> Get();
    }
}
