using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MvcCoreTut.Models.Domain
{
    public class Person
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string? Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        
        public string? Email { get; set; }
    }


}
