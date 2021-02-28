using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Username { get; set; }
        [Required] [JsonIgnore] public string Password { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}