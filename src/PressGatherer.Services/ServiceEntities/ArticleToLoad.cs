using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PressGatherer.Services.ServiceEntities
{
    public class ArticleToLoad
    {
        public string PageId { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Culture { get; set; }
        public string ImageLink { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }

        public ArticleToLoad(string pageId)
        {
            this.PageId = pageId;
            this.Link = "";
            this.Title = "";
            this.Description = "";
            this.Category = "";
            this.Culture = "";
            this.ImageLink = "";
            this.Content = "";
            this.HtmlContent = "";
            this.PublicationDate = null;
        }

        public ArticleToLoad(string pageId, string link)
        {
            this.PageId = pageId;
            this.Link = link;
            this.Title = "";
            this.Description = "";
            this.Category = "";
            this.Culture = "";
            this.ImageLink = "";
            this.Content = "";
            this.HtmlContent = "";
            this.PublicationDate = null;
        }

        public ArticleToLoad(string pageId, string link, string title, string description)
        {
            this.PageId = pageId;
            this.Link = link;
            this.Title = title;
            this.Description = description;
            this.Category = "";
            this.Culture = "";
            this.ImageLink = "";
            this.Content = "";
            this.HtmlContent = "";
            this.PublicationDate = null;
        }

        public ArticleToLoad(string pageId, string link, string title, string description, string category, DateTime pubDate)
        {
            this.PageId = pageId;
            this.Link = link;
            this.Title = title;
            this.Description = description;
            this.Category = "";
            this.Culture = "";
            this.ImageLink = "";
            this.Content = "";
            this.HtmlContent = "";
            this.PublicationDate = pubDate;
        }
    }
}
