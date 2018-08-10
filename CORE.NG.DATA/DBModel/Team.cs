using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CORE.NG.DATA.DBModel
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string name { get; set; }

        //[ForeignKey("uid")]
        public List<user> user { get; set; }
    }
}
