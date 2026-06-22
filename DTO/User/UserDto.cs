using System.Text.Json.Serialization;
using Api.Models.Enums;

namespace Api.DTO
{
    public class UserDto
    {
        public string? Name {get; set;}
        public string? Email{get; set;}
        public string? Password {get; set;}
        public string? Phone {get; set; }
        public Roles Role {get; set; }
    }
}