using System.ComponentModel.DataAnnotations;

namespace GTechProje.API.Models
{
    public class Number
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

       
    }
}
