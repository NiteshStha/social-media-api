using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PostId { get; set; }

        public string PostTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ImagePath { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}