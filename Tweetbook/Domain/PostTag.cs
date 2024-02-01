using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tweetbook.Domain
{
    public class PostTag
    {
        public string TagName { get; set; }

        [ForeignKey(nameof(TagName))]
        public virtual Tag Tag { get; set; }

        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
