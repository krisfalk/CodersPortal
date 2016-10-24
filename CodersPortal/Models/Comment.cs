using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodersPortal.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("NewsArticle")]
        public int NewsArticleId { get; set; }
        public virtual NewsArticle NewsArticle { get; set; }
        public string Name { get; set; }
        public string UserComment { get; set; }
        public DateTime postDate { get; set; }
    }
}