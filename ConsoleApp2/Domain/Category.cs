using ConsoleApp2.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2.Domain
{
    public class Category : IEntity<byte>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        public string Name { get; set; }
    }
}
