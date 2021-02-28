using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required] public string CommentDescription { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}