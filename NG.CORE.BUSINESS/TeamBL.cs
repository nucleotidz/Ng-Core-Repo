using CORE.NG.CACHE;
using CORE.NG.DATA.DBModel;
using CORE.NG.DATA.Repository;
using CORE.NG.MODELS;
using System.Collections.Generic;

namespace NG.CORE.BUSINESS
{
    public class TeamBL : ITeamBL
    {
        ITeamRepository teamRepository;
        public TeamBL(ITeamRepository _teamRepository)
        {
            this.teamRepository = _teamRepository;
        }
        public void Save()
        {
            this.teamRepository.Save();

        }
        public List<TeamDTO> Get()
        {
            return this.teamRepository.Get();

        }
    }
}
