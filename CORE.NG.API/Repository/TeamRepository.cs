using CORE.NG.API.DBModel;
using CORE.NG.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.NG.API.Repository
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {     

        /// <summary>
        /// _unitOfWork IUnitOfWork
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<Team> _repository;

        public TeamRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = this._unitOfWork.GetRepository<Team>();

        }

        public void Save()
        {
            Team team = new Team();
            team.name = "Shobhit";
            this._repository.Insert(team);
            this._unitOfWork.Commit();
        }

        public List<user> Get()
        {
            return (from users in this._repository.Query<user>()
                        select users).ToList();
        }

    }
}
