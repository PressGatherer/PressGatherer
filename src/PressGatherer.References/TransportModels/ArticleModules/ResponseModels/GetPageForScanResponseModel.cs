using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class GetPageForScanResponseModel
    {
        public string PageId { get; set; }
        public string RssLink { get; set; }
        public string SearchLink { get; set; }
        public DateTime LastScan { get; set; }
        public bool OnLoad { get; set; }

        public GetPageForScanResponseModel()
        {
            this.PageId = "";
            this.RssLink = "";
            this.SearchLink = "";
            this.LastScan = DateTime.MinValue;
        }
    }
}

