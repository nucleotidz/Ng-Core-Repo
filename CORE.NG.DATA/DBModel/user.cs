using System.ComponentModel.DataAnnotations;

namespace CORE.NG.DATA.DBModel
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(15)]
        public string Name { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}
