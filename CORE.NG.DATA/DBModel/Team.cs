using CORE.NG.DATA.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CORE.NG.DATA.DBModel
{
    [System.Serializable]
    public class Team: ISupportIdentity
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string name { get; set; }
        public List<user> user { get; set; }
    }
}
