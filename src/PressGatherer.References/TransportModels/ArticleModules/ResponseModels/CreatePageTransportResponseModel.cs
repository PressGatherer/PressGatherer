using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class CreatePageTransportResponseModel
    {
        public string PageId { get; set; }

        public CreatePageTransportResponseModel()
        {
            this.PageId = "";
        }

        public CreatePageTransportResponseModel(string pageId)
        {
            this.PageId = pageId;
        }

    }
}