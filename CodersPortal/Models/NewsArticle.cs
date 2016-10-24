using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodersPortal.Models
{
    public class NewsArticle
    {
        [Key]
        public int NewsArticleId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string ImageUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}