using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.NG.API.DBModel
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
