using CORE.NG.DATA.Context;
using System.ComponentModel.DataAnnotations;

namespace CORE.NG.DATA.DBModel
{
    public class user: ISupportIdentity
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(15)]
        public string Name { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}
