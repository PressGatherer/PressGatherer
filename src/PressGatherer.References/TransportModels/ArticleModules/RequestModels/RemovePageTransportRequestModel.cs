using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class RemovePageTransportRequestModel
    {
        public string PageId { get; set; }

        public RemovePageTransportRequestModel(string pageId="")
        {
            this.PageId = pageId;
        }
    }
}
