using CORE.NG.VALIDATION;
using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.NG.MODELS
{
    public class TeamDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Team Name is Mandatory")]
        [ValidateTeam("A", ErrorMessage = "Team Name Should Start with A")]
        public string name { get; set; }
    }
}
