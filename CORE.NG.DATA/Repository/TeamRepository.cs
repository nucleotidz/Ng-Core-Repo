using CORE.NG.CACHE;
using CORE.NG.DATA.Context;
using CORE.NG.DATA.DBModel;
using CORE.NG.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.NG.DATA.Repository
{
    public class TeamRepository : ITeamRepository
    {

        private readonly IDataContext _repository;

        public TeamRepository(IDataContext repository)

        {
            this._repository = repository;

        }

        public void Save()
        {
            CacheManager.Remove("teams");
            Team team = new Team();
            team.name = "Shobhit";
            this._repository.Insert<Team>(team);
            this._repository.SaveChanges();
        }

        public List<TeamDTO> Get()
        {
            List<Team> team = CacheManager.Get<List<Team>>("teams");
            if (team == null)
            {
                team = (from users in this._repository.GetQuery<Team>()
                        select users).ToList();
            }
            return team.Select(x => new TeamDTO {
                Id=x.Id,
                name=x.name
            }).ToList();
        }

    }
}
