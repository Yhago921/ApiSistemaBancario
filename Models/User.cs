using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api.Models.Enums;

namespace Api.Models
{
    public class User
    {
        public int Id {get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name {get; set;}
        [Required]
        [EmailAddress]
        public string? Email{get; set;}
        [Required]
        public string? Password {get; set;}
        [Required]
        public string? Phone {get; set; }
        [Required]
        public Roles Role {get; set; }
        [JsonIgnore]
        public List<Account>? Accounts {get; set; }
    }
}