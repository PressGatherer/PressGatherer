using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class CreatePageTransportRequestModel
    {
        public string Name { get; set; }

        public string BaseLink { get; set; }

        public string SearchLink { get; set; }

        public string RssLink { get; set; }

        public CreatePageTransportRequestModel()
        {
            this.BaseLink = "";
            this.Name = "";
            this.RssLink = "";
            this.SearchLink = "";
        }

        public CreatePageTransportRequestModel(string name, string baseLink, string searchLink, string rssLink)
        {
            this.BaseLink = baseLink;
            this.Name = name;
            this.RssLink = rssLink;
            this.SearchLink = searchLink;
        }

    }
}
